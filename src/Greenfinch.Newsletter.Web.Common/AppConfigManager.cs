using Greenfinch.Newsletter.Web.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Greenfinch.Newsletter.Web.Common
{

    /// <summary>
    /// Class to provide easiest way to safely access appsettings.
    /// </summary>
    public class AppConfigManager : IAppConfigManager
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _appSettings;

       public AppConfigManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _appSettings = configuration.GetSection("ApplicationSettings");
        }
        /// <summary>
        /// Get appSettings value from configuration file
        /// </summary>
        /// <typeparam name="T">Type of the expected value</typeparam>
        /// <param name="key">key of appSettings to get value of</param>
        /// <returns>value of appSettings key</returns>
        /// <exception cref="NullReferenceException">If appSettings configuration key is not found in web.config</exception>
        public  T GetAppSettingsValue<T>(string key)
        {
            var value = _appSettings[key];
            if (value == null)
                throw new NullReferenceException();
            else
                return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// Get appSettings value from configuration file, and returns the default value if not found.
        /// </summary>
        /// <typeparam name="T">Type of the expected value</typeparam>
        /// <param name="key">key of appSettings to get value of</param>
        /// <param name="defaultValue">the default value</param>
        /// <returns>value of appSettings key</returns>
        /// <exception cref="NullReferenceException">If appSettings configuration key is not found in web.config</exception>
        public  T GetAppSettingsValueOrDefault<T>(string key, T defaultValue)
        {
            var value = _appSettings[key];
            if (value == null)
                return defaultValue;
            else
                return (T)Convert.ChangeType(value, typeof(T));
        }
    }


}
