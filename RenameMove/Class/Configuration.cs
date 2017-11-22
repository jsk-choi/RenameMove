using System;
using System.Collections.Generic;
using System.Configuration;

namespace RenameMove
{
    public class Configuration : IConfiguration
    {
        public IEnumerable<string> PathsToProcess { get; set; }
        public IEnumerable<string> VideoFileTypeExtensions { get; set; }

        public Configuration() {
            PathsToProcess = GetSettingScalar("PathsToProcess").Split(',');
            VideoFileTypeExtensions = GetSettingScalar("VideoFileTypeExtensions").Split(',');
        }
        public string GetSettingScalar(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
