using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TicTacToe.BL.Annotations;
using TicTacToe.BL.DTOs.GameParticipation;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.DTOs.Game
{
    public class GameCreateDTO : INotifyPropertyChanged
    {
        private GameType type = GameType.Multiplayer;

        public GameType Type
        {
            get => type;
            set
            {
                type = value;
                Difficulty = type == GameType.Solo ? AiDifficulty.Normal : AiDifficulty.None;
            }
        }

        public AiDifficulty Difficulty{ get; set; } = AiDifficulty.Normal;

        public int BoardSize { get; set; } = 20;

        public List<GameParticipationDTO> GameParticipation { get; set; } = new();


        // TODO: remove
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}