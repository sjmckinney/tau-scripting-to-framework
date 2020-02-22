using System.IO;
using Newtonsoft.Json;
using Framework.Config;

namespace Framework
{
    public static class FW
    {
        private static FwConfig _config;
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        public static FwConfig Config => _config ?? throw new System.NullReferenceException("_config is null. Call SetConfig() to initialise.");
        
        public static void SetConfig()
        {
            if (_config == null)
            {
                var jsonStr = File.ReadAllText(WORKSPACE_DIRECTORY + "/framework-config.json");
                _config= JsonConvert.DeserializeObject<FwConfig>(jsonStr);
            }
        }
    }
}