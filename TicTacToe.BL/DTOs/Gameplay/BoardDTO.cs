using System.Collections.Generic;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class BoardDTO
    {
        public int BoardSize { get; }

        public List<BoardCellDTO> Cells { get; }

        public BoardDTO(int boardSize, List<BoardCellDTO> cells)
        {
            BoardSize = boardSize;
            Cells = cells;
        }
        
    }
}