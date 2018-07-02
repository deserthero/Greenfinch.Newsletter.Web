using System;
using System.Collections.Generic;
using System.Text;

namespace Greenfinch.Newsletter.Web.Common.Interfaces
{
    /// <summary>
    /// Interface to provide easy of use implementation to access appsettings
    /// </summary>
    public interface IAppConfigManager
    {
        T GetAppSettingsValue<T>(string key);
        T GetAppSettingsValueOrDefault<T>(string key, T defaultValue);
    }
}
