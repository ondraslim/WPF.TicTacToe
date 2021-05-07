using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TicTacToe.BL.DTOs.Gameplay.Common;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class BoardDTO : GameplayBaseDTO
    {
        public int Size { get; }

        public ObservableCollection<BoardCellDTO> Cells { get; private set; }

        public BoardDTO(int size, List<BoardCellDTO> cells)
        {
            Size = size;
            Cells = new ObservableCollection<BoardCellDTO>(cells);
        }

        public void ClearCells()
        {
            var clearedCells = Cells.Select(c => new BoardCellDTO { Row = c.Row, Col = c.Col });
            Cells = new ObservableCollection<BoardCellDTO>(clearedCells);
        }

        public BoardCellDTO GetCell(int x, int y)
        {
            var idx = x * Size + y;
            return Cells.ElementAtOrDefault(idx);
        }
    }
}