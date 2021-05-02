using AutoMapper;
using System;
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

        public async Task<UserDTO> LoginAsync(UserCreateDTO user)
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
            finally
            {
                await uow.CommitAsync();
            }

            currentUserProvider.SetCurrentUser(authorizedUser);

            return authorizedUser;
        }

        public async Task<UserDTO> RegisterAsync(UserCreateDTO registration)
        {
            var user = mapper.Map<User>(registration);
            
            var (hash, salt) = passwordHasher.CreateHash(registration.Password);
            user.PasswordHash = string.Join(',', hash, salt);
            user.PreferredLanguage = "en";

            using var uow = UnitOfWorkProvider.Create();
            user.Id = userRepository.Create(user);
            await uow.CommitAsync();
            
            var authorizedUser = mapper.Map<UserDTO>(user);
            currentUserProvider.SetCurrentUser(authorizedUser);
            
            return authorizedUser;
        }

        public UserDTO GetUserInfo(Guid userId)
        {
            throw new NotImplementedException();
        }

        private async Task<UserDTO> AuthorizeUserAsync(UserCreateDTO user)
        {
            var storedUser = await userRepository.GetUserByNameAsync(user.Name);
            if (storedUser is null)
            {
                throw new EntityNotFoundException($"User with name '{user.Name}' was not found.");
            }

            var userEntity = await userRepository.GetByIdAsync(storedUser.Id);

            string hash;
            string salt;

            (hash, salt) = userEntity is not null ? passwordHasher.GetPassAndSalt(userEntity.PasswordHash) : (string.Empty, string.Empty);
            var succ = userEntity is not null && passwordHasher.VerifyHashedPassword(hash, salt, user.Password);

            if (!succ) throw new UserAuthException($"Password verification for user '{user.Name}' failed.");

            return mapper.Map<UserDTO>(userEntity);
        }
    }
}