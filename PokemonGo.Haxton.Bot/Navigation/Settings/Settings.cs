using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace PokemonGo.Haxton.Bot.Settings
{
    public class Settings : ISettings
    {
        public Settings()
        {
            AuthType =
                (AuthType)Enum.Parse(typeof(AuthType), ConfigurationManager.AppSettings["AccountType"]);
            DefaultLatitude = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultLatitude"], CultureInfo.InvariantCulture);
            DefaultLongitude = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultLongitude"], CultureInfo.InvariantCulture);
            DefaultAltitude = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultAltitude"], CultureInfo.InvariantCulture);
            PtcUsername = ConfigurationManager.AppSettings["PtcUsername"];
            PtcPassword = ConfigurationManager.AppSettings["PtcPassword"];

            GoogleUsername = ConfigurationManager.AppSettings["GoogleEmail"];
            GooglePassword = ConfigurationManager.AppSettings["GooglePassword"];
            Proxy = ConfigurationManager.AppSettings["Proxy"];
        }

        public AuthType AuthType { get; set; }
        public double DefaultLatitude { get; set; }
        public double DefaultLongitude { get; set; }
        public double DefaultAltitude { get; set; }

        private string _googleRefreshToken;

        public string GoogleRefreshToken
        {
            get
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\Configs\\GoogleAuth.ini"))
                    _googleRefreshToken = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Configs\\GoogleAuth.ini");
                return _googleRefreshToken;
            }
            set
            {
                if (!File.Exists(Directory.GetCurrentDirectory() + "\\Configs"))
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Configs");
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Configs\\GoogleAuth.ini", value);
                _googleRefreshToken = value;
            }
        }

        public string DeviceId { get; set; }
        public string AndroidBoardName { get; set; }
        public string AndroidBootloader { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceModelIdentifier { get; set; }
        public string DeviceModelBoot { get; set; }
        public string HardwareManufacturer { get; set; }
        public string HardwareModel { get; set; }
        public string FirmwareBrand { get; set; }
        public string FirmwareTags { get; set; }
        public string FirmwareType { get; set; }
        public string FirmwareFingerprint { get; set; }

        public string PtcPassword { get; set; }
        public string PtcUsername { get; set; }
        public string GoogleUsername { get; set; }
        public string GooglePassword { get; set; }
        //public string ApiUrl { get; set; }
        public string Proxy { get; set; }
        public bool UseProxy { get; set; }
        public bool UseProxyAuthentication { get; set; }
        public string UseProxyHost { get; set; }
        public string UseProxyPort { get; set; }
        public string UseProxyUsername { get; set; }
        public string UseProxyPassword { get; set; }
    }
}