using System.Collections.Generic;
using System.Globalization;

namespace TicTacToe.Core.Services.Interfaces
{
    public interface ILocalizationService
    {
         IList<CultureInfo> SupportedLanguages { get; }
         CultureInfo CurrentCultureInfo { get; }

         void SetCulture(CultureInfo cultureInfo);
    }
}