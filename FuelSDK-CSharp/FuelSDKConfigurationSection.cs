using System;

namespace FuelSDK
{
    /// <summary>
    /// FuelSDKConfigurationSection - Represents ConfigurationSection
    /// </summary>
    public class FuelSDKConfigurationSection
    {
        /// <summary>
        /// Gets or sets the app signature.
        /// </summary>
        /// <value>The app signature.</value>
        public string AppSignature { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        /// <value>The client secret.</value>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the SOAP end point.
        /// </summary>
        /// <value>The SOAP end point.</value>
        public string SoapEndPoint { get; set; }

        public string AuthenticationEndPoint { get; set; }

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <returns>The clone.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
