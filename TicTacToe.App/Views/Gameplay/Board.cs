using System.Collections.ObjectModel;
using System.Linq;

namespace TicTacToe.App.Views.Gameplay
{
    public class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private ObservableCollection<BoardCell> cells;

        public ObservableCollection<BoardCell> Cells
        {
            get
            {
                return cells ??= new ObservableCollection<BoardCell>(
                    Enumerable.Range(0, Rows * Columns)
                        .Select(i => new BoardCell())
                    );
            }
        }
    }
}