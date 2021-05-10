using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Exceptions;
using TicTacToe.BL.Facades.Common;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.BL.Repositories.Interfaces;
using TicTacToe.BL.Services;
using TicTacToe.Data.Models;
using TicTacToe.Infrastructure.Services.Interfaces;
using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.BL.Facades
{
    public class UserFacade : FacadeBase, IUserFacade
    {
        private readonly IUserRepository userRepository;
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly IMapper mapper;
        private readonly IPasswordHasher passwordHasher;

        public UserFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            ICurrentUserProvider currentUserProvider,
            IUserRepository userRepository,
            IMapper mapper,
            IPasswordHasher passwordHasher) : base(unitOfWorkProvider)
        {
            this.currentUserProvider = currentUserProvider;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public async Task<List<UserDTO>> GetUserListAsync()
        {
            using var uow = UnitOfWorkProvider.Create();
            var users = await userRepository.GetAllAsync();
            return users.Select(u => mapper.Map<UserDTO>(u)).ToList();
        }

        public async Task<UserDTO> LoginAsync(UserLoginDTO user)
        {
            using var uow = UnitOfWorkProvider.Create();

            UserDTO authorizedUser;
            try
            {
                authorizedUser = await AuthorizeUserAsync(user);
            }
            catch (Exception e)
            {
                throw new UserAuthException($"Error while trying to login user '{user.Name}'", e);
            }

            currentUserProvider.SetCurrentUser(authorizedUser);

            return authorizedUser;
        }

        public async Task<UserDTO> RegisterAsync(UserRegisterDTO registration)
        {
            if (registration.Password != registration.PasswordConfirmation)
                throw new UserAuthException("Passwords do no match!");

            var user = PrepareNewUser(registration);

            using var uow = UnitOfWorkProvider.Create();
            user.Id = await userRepository.CreateAsync(user);
            await uow.CommitAsync();
            
            var authorizedUser = mapper.Map<UserDTO>(user);
            currentUserProvider.SetCurrentUser(authorizedUser);
            
            return authorizedUser;
        }

        public async Task ChangeUserPasswordAsync(PasswordChangeDTO passwordChange)
        {
            if (passwordChange.NewPassword != passwordChange.NewPasswordConfirmation) return;

            using var uow = UnitOfWorkProvider.Create();

            var user = await userRepository.GetByIdAsync(passwordChange.UserId);
            if (user is null) 
                throw new EntityNotFoundException($"User with id '{passwordChange.UserId}' was not found.");

            if (!IsLoginCredentialsValid(passwordChange.OldPassword, user))
                throw new UserAuthException($"Password verification for user '{passwordChange.UserId}' failed.");

            user.PasswordHash = GetPasswordHash(passwordChange.NewPassword);

            await uow.CommitAsync();
        }

        private User PrepareNewUser(UserRegisterDTO registration)
        {
            var user = mapper.Map<User>(registration);
            user.PasswordHash = GetPasswordHash(registration.Password);
            return user;
        }

        private string GetPasswordHash(string password)
        {
            var (hash, salt) = passwordHasher.CreateHash(password);
            return string.Join(',', hash, salt);
        }

        private async Task<UserDTO> AuthorizeUserAsync(UserLoginDTO user)
        {
            var entity = await userRepository.GetUserByNameAsync(user.Name);
            if (entity is null)
                throw new EntityNotFoundException($"User with name '{user.Name}' was not found.");

            if (!IsLoginCredentialsValid(user, entity))
                throw new UserAuthException($"Password verification for user '{user.Name}' failed.");

            return mapper.Map<UserDTO>(entity);
        }

        private bool IsLoginCredentialsValid(UserLoginDTO user, User userEntity) 
            => IsLoginCredentialsValid(user.Password, userEntity);

        private bool IsLoginCredentialsValid(string inputPassword, User userEntity)
        {
            string hash;
            string salt;

            (hash, salt) = userEntity is not null ? passwordHasher.GetPassAndSalt(userEntity.PasswordHash) : (string.Empty, string.Empty);
            return userEntity is not null && passwordHasher.VerifyHashedPassword(hash, salt, inputPassword);
        }
    }
}