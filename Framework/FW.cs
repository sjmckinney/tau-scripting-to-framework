using System.IO;
using static NLog.LogManager;
using Newtonsoft.Json;
using Framework.Config;

namespace Framework
{
    public static class FW
    {
        private static readonly NLog.Logger logger = GetCurrentClassLogger();
        private static FwConfig _config;
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        public static FwConfig Config => _config ?? throw new System.NullReferenceException("_config is null. Call SetConfig() to initialise.");
        
        public static void Init()
        {
            logger.Info("\n\r --------------------------- Beginning test run ---------------------------");
            SetConfig();
            SetLogDirectory();
        }
        
        public static void SetConfig()
        {
            if (_config == null)
            {
                var jsonStr = File.ReadAllText(WORKSPACE_DIRECTORY + "/framework-config.json");
                _config= JsonConvert.DeserializeObject<FwConfig>(jsonStr);
                logger.Info("Retrieved config info");
            }
        }

        public static void SetLogDirectory()
        {
            var logDir = WORKSPACE_DIRECTORY + "Logs";

            logger.Info($"Value of logDir: {logDir}");

            if(!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
                logger.Info($"Created log directory");
            }
        }
    }
}