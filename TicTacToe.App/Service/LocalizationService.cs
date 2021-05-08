using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using TicTacToe.App.Localization;
using TicTacToe.Core.Services.Interfaces;

namespace TicTacToe.App.Service
{
    public class LocalizationService : ILocalizationService
    {
        public IList<CultureInfo> SupportedLanguages { get; }

        public CultureInfo CurrentCultureInfo => Thread.CurrentThread.CurrentUICulture;

        public LocalizationService()
        {
            SupportedLanguages = new List<CultureInfo> { new("en"), new("cs-CZ") };
            Thread.CurrentThread.CurrentUICulture = SupportedLanguages.First();
        }

        public void SetCulture(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Texts.Culture = cultureInfo;
        }
    }
}