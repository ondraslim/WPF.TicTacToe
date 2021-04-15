using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TicTacToe.App.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection LastHourSeries { get; set; }
        public SeriesCollection LastHourSeries1 { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {25,52,61,89},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },
                 new StackedColumnSeries
                {
                    Values = new ChartValues<double> {-15,-75,-16,-49},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
            };
            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new(3),
                        new(1),
                        new(9),
                        new(4),
                        new(5),
                        new(3),
                        new(1),
                        new(2),
                        new(3),
                        new(7),
                    }
                }
            };
            LastHourSeries1 = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new(13),
                        new(11),
                        new(9),
                        new(14),
                        new(5),
                        new(3),
                        new(12),
                        new(2),
                        new(3),
                        new(7),
                    }
                }
            };
            Labels = new[] { "Feb 7", "Feb 8", "Feb 9", "Feb 10" };
            Formatter = value => value.ToString();
            DataContext = this;
            string imgCartoon = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent}\\Images\\cartoon-woman-pretty.png";
            string imgavatar = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent}\\Images\\avatar1.jpg";
            ImgCartoon.Source = new BitmapImage(new Uri(imgCartoon));
            avatar1.Source = new BitmapImage(new Uri(imgavatar));
            avatar2.Source = new BitmapImage(new Uri(imgavatar));
        }
    }
}
