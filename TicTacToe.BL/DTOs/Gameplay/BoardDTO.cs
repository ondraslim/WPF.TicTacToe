using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class BoardDTO
    {
        public int Size { get; }

        public List<BoardCellDTO> Cells { get; }

        public BoardDTO(int size, List<BoardCellDTO> cells)
        {
            Size = size;
            Cells = cells;
        }

        public BoardCellDTO GetCell(int x, int y)
        {
            var idx = x * Size + y;
            return Cells.ElementAtOrDefault(idx);
        }
    }
}