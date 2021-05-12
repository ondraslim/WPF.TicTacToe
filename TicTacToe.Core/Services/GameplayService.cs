using System.Linq;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.Core.Services.Interfaces;

namespace TicTacToe.Core.Services
{
    public class GameplayService : IGameplayService
    {
        private const int RequiredCellsToWin = 5;

        public bool CheckIsWin(BoardDTO board, BoardCellDTO selectedCell)
        {
            return IsWinInBoardRow(board, selectedCell) ||
                   IsWinInBoardColumn(board, selectedCell) ||
                   IsWinInBoardDiagonal(board, selectedCell) ||
                   IsWinInReverseBoardDiagonal(board, selectedCell);
        }

        private static bool IsWinInBoardRow(BoardDTO board, BoardCellDTO selectedCell)
        {
            char prevSign = default;
            char currSign = default;
            int sameSignInRowCount = 0;

            var row = selectedCell.Row;
            for (var col = selectedCell.Col - RequiredCellsToWin + 1; col < selectedCell.Col + RequiredCellsToWin; col++)
            {
                if (col < 0 || col >= board.Size) continue;
                prevSign = currSign;

                var cell = board.GetCell(row, col);
                if (cell.IsEmpty) continue;

                currSign = cell.Sign;

                if (prevSign != currSign)
                {
                    sameSignInRowCount = 1;
                    continue;
                }

                sameSignInRowCount++;

                if (sameSignInRowCount == RequiredCellsToWin)
                {
                    var winningCells = board.Cells.Where(c => c.Row == row && c.Col <= col && c.Col > col - RequiredCellsToWin);
                    foreach (var winningCell in winningCells)
                    {
                        winningCell.IsWinningCell = true;
                    }

                    return true;
                }
            }

            return false;
        }

        private static bool IsWinInBoardColumn(BoardDTO board, BoardCellDTO selectedCell)
        {
            char prevSign = default;
            char currSign = default;
            int sameSignInRowCount = 0;

            var col = selectedCell.Col;
            for (var row = selectedCell.Row - RequiredCellsToWin + 1; row < selectedCell.Row + RequiredCellsToWin; row++)
            {
                if (row < 0 || row >= board.Size) continue;
                prevSign = currSign;

                var cell = board.GetCell(row, col);
                if (cell.IsEmpty) continue;

                currSign = cell.Sign;

                if (prevSign != currSign)
                {
                    sameSignInRowCount = 1;
                    continue;
                }

                sameSignInRowCount++;

                if (sameSignInRowCount == RequiredCellsToWin)
                {
                    var winningCells = board.Cells.Where(c => c.Col == col && c.Row <= row && c.Row > row - RequiredCellsToWin);
                    foreach (var winningCell in winningCells)
                    {
                        winningCell.IsWinningCell = true;
                    }

                    return true;
                }
            }

            return false;
        }

        private static bool IsWinInBoardDiagonal(BoardDTO board, BoardCellDTO selectedCell)
        {
            char prevSign = default;
            char currSign = default;
            var sameSignInRowCount = 0;

            for (var adj = 1 - RequiredCellsToWin; adj < RequiredCellsToWin; adj++)
            {
                var row = selectedCell.Row + adj;
                var col = selectedCell.Col + adj;

                if (row < 0 || row >= board.Size) continue;
                if (col < 0 || col >= board.Size) continue;

                prevSign = currSign;

                var cell = board.GetCell(row, col);
                if (cell.IsEmpty) continue;

                currSign = cell.Sign;

                if (prevSign != currSign)
                {
                    sameSignInRowCount = 1;
                    continue;
                }

                sameSignInRowCount++;

                if (sameSignInRowCount == RequiredCellsToWin)
                {
                    for (var i = 0; i < RequiredCellsToWin; i++)
                    {
                        board.GetCell(row - i, col - i).IsWinningCell = true;
                    }

                    return true;
                }
            }

            return false;
        }

        private static bool IsWinInReverseBoardDiagonal(BoardDTO board, BoardCellDTO selectedCell)
        {
            char prevSign = default;
            char currSign = default;
            var sameSignInRowCount = 0;

            for (var adj = 1 - RequiredCellsToWin; adj < RequiredCellsToWin; adj++)
            {
                var row = selectedCell.Row + adj;
                var col = selectedCell.Col - adj;

                if (row < 0 || row >= board.Size) continue;
                if (col < 0 || col >= board.Size) continue;
                prevSign = currSign;

                var cell = board.GetCell(row, col);
                if (cell.IsEmpty) continue;

                currSign = cell.Sign;

                if (prevSign != currSign)
                {
                    sameSignInRowCount = 1;
                    continue;
                }

                sameSignInRowCount++;

                if (sameSignInRowCount == RequiredCellsToWin)
                {
                    for (var i = 0; i < RequiredCellsToWin; i++)
                    {
                        board.GetCell(row - i, col + i).IsWinningCell = true;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}