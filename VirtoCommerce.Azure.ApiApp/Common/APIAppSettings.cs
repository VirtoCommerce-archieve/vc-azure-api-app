using System.Configuration;

namespace VirtoCommerce.Azure.ApiApp.Common
{
    public static class APIAppSettings
    {
        public static string ApiKey { get { return GetSettingValue("Api_Key"); } }
        public static string AppId { get { return GetSettingValue("App_Id"); } }
        public static string BasePath { get { return GetSettingValue("Base_Path"); } }

        private static string GetSettingValue(string settingName)
        {
            return ConfigurationManager.AppSettings.Get(settingName);
        }

    }
}