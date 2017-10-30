using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// Config 管理
    /// </summary>
    public class ConfigManager : JsonManager
    {
        /// <summary>
        /// config.json 檔案路徑
        /// </summary>
        const string FILEPATH = @"D:\\Projects\\oop-homework-dotnet-core\\Services\\configs\\config.json";

        /// <summary>
        /// Config List
        /// </summary>
        private readonly List<Config> configs = new List<Config>();

        /// <summary>
        /// 以 index 方式讀取物件屬性
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>configs[index]</returns>
        public Config this[int index] => configs[index];

        /// <summary>
        /// 筆數
        /// </summary>
        public int Count => configs.Count;

        /// <summary>
        /// 處理 config.json 設定檔
        /// </summary>
        public override void ProcessJsonConfig()
        {
            // 讀取 json 檔取得 JObject
            JObject obj = GetJsonObject(FILEPATH);

            // 整理成 Config 放到 configs
            foreach (JToken config in obj["configs"])
            {
                configs.Add(new Config(config));
            }
        }
    }
}
