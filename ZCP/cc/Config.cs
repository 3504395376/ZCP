using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
namespace ZCP.cc
{
    class Config
    {
        private static void SetKeyValue(string key,string value)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings[key].Value = value;
            cfa.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        private static string GetKeyValue(string key)
        {
            String value = ConfigurationManager.AppSettings[key];
            return value;
        }
        public static string GetCardPath()
        {
            return GetKeyValue("CardPath");
        }
        public static string GetCacheImgPath()
        {
            return GetKeyValue("CacheImgPath");
        }
        public static string GetLeftPath()
        {
            return GetKeyValue("LeftImgPath");
        }
        public static string GetRightImgPath()
        {
            return GetKeyValue("RightImgPath");
        }
        public static string GetDownImgPath()
        {
            return GetKeyValue("DownImgPath");
        }
        public static string GetZcpImgPath()
        {
            return GetKeyValue("ZcpImgPath");
        }
        public static string GetZjImgPath()
        {
            return GetKeyValue("ZjImgPath");
        }
    }
}
