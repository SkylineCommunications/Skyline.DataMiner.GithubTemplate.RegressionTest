namespace Library.QAPortal
{
    using System;
    using System.IO;
    using Newtonsoft.Json;

    public class QaPortalConfiguration
    {
        private const string ConfigurationFilePath = @"C:\Skyline DataMiner\QAPortal\QaPortalConfiguration.json";

        public string Path { get; set; }

        public string ClientId { get; set; }

        public string ApiKey { get; set; }

        public static QaPortalConfiguration GetConfiguration(out Exception exception)
        {
            exception = null;

            try
            {
                return JsonConvert.DeserializeObject<QaPortalConfiguration>(File.ReadAllText(ConfigurationFilePath));
            }
            catch (Exception e)
            {
                exception = e;
                return null;
            }
        }
    }
}