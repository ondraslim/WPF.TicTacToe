using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TicTacToe.BL.DTOs.Gameplay.Common;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class BoardDTO : GameplayBaseDTO
    {
        public int Size { get; }

        public ObservableCollection<BoardCellDTO> Cells { get; }

        public BoardDTO(int size, List<BoardCellDTO> cells)
        {
            Size = size;
            Cells = new ObservableCollection<BoardCellDTO>(cells);
        }

        public BoardCellDTO GetCell(int x, int y)
        {
            var idx = x * Size + y;
            return Cells.ElementAtOrDefault(idx);
        }
    }
}