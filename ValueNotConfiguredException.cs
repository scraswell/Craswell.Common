using System;
using System.Runtime.Serialization;

namespace Craswell.Common
{
    /// <summary>
    /// An exception thrown when configuration data is missing.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ValueNotConfiguredException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueNotConfiguredException"/> class.
        /// </summary>
        public ValueNotConfiguredException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueNotConfiguredException"/> class.
        /// </summary>
        /// <param name="appSettingsKey">The appSettings key that does not have a configured value.</param>
        public ValueNotConfiguredException(
            string appSettingsKey)
            : base(BuildMessage(appSettingsKey))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueNotConfiguredException"/> class.
        /// </summary>
        /// <param name="message">The appSettings key that does not have a configured value.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ValueNotConfiguredException(
            string appSettingsKey,
            Exception innerException)
            : base(BuildMessage(appSettingsKey), innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueNotConfiguredException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <param name="streamingContext">The streaming context.</param>
        protected ValueNotConfiguredException(
            SerializationInfo serializationInfo,
            StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        /// <summary>
        /// Builds the message.
        /// </summary>
        /// <param name="appSettingsKey">The application settings key.</param>
        /// <returns></returns>
        private static string BuildMessage(
            string appSettingsKey)
        {
            return string.Format(
                "No value is configured for the appSettings key '{0}'.  Please configure an appropriate value.",
                appSettingsKey);
        }
    }
}
