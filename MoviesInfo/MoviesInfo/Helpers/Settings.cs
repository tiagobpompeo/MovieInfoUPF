using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MoviesInfo.Helpers
{
    public static class Settings
    {

        private static ISettings AppSettings => CrossSettings.Current;

        public static string IdFilme
        {
            get => AppSettings.GetValueOrDefault(nameof(IdFilme), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(IdFilme), value);

        }
    }
}
