using System;
using System.Collections.Specialized;

namespace Craswell.Common
{
    /// <summary>
    /// Configuration manager extensions.
    /// </summary>
    public static class ConfigurationManagerExtensions
    {
        /// <summary>
        /// Gets the specified application settings key.
        /// </summary>
        /// <typeparam name="T">The expected type.</typeparam>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="appSettingsKey">The application settings key.</param>
        /// <returns>The configured value.</returns>
        /// <exception cref="Craswell.Common.ValueNotConfiguredException"></exception>
        public static T Get<T>(
            this NameValueCollection appSettings,
            string appSettingsKey)
        {
            var configuredValue = appSettings[appSettingsKey];

            if (string.IsNullOrEmpty(configuredValue))
            {
                throw new ValueNotConfiguredException(appSettingsKey);
            }

            T castedValue;

            try
            {
                castedValue = (T)Convert.ChangeType(configuredValue, typeof(T));
            }
            catch(Exception e)
            {
                throw new ValueNotConfiguredException(
                    appSettingsKey,
                    e);
            }

            return castedValue;
        }

        /// <summary>
        /// Gets the specified application settings key.
        /// </summary>
        /// <typeparam name="T">The expected type.</typeparam>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="appSettingsKey">The application settings key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The configured value.</returns>
        /// <exception cref="Craswell.Common.ValueNotConfiguredException"></exception>
        public static T Get<T>(
            this NameValueCollection appSettings,
            string appSettingsKey,
            T defaultValue)
        {
            var configuredValue = appSettings[appSettingsKey];

            if (string.IsNullOrEmpty(configuredValue))
            {
                return defaultValue;
            }

            try
            {
                return (T)Convert.ChangeType(configuredValue, typeof(T));
            }
            catch (Exception)
            {
            }

            return defaultValue;
        }
    }
}
