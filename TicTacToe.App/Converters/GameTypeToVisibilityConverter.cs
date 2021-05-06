using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.App.Converters
{
    public class GameTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value is GameType gameType ? gameType : (GameType) 0;
            return type == GameType.Solo ? Visibility.Visible : Visibility.Hidden;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}