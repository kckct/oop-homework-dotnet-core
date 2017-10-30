using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace Services
{
    /// <summary>
    /// Config 管理
    /// </summary>
    public class ConfigManager
    {
        /// <summary>
        /// config.json 檔案路徑
        /// </summary>
        const string FILEPATH = @"D:\\Projects\\oop-homework-dotnet-core\\Services\\configs\\config.json";

        /// <summary>
        /// Config List
        /// </summary>
        private List<Config> configs = new List<Config>();

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
        public void ProcessConfigs()
        {
            // 讀取 json 檔取得 JObject
            JObject obj = GetJsonObject();

            // 整理成 Config 放到 configs
            foreach (JToken config in obj["configs"])
            {
                configs.Add(new Config(config));
            }
        }

        /// <summary>
        /// 讀取 json 檔取得 JObject
        /// </summary>
        /// <returns>JObject</returns>
        private JObject GetJsonObject()
        {
            // 讀取 json 檔
            string json = File.ReadAllText(FILEPATH);

            // json parse
            return JObject.Parse(json);
        }
    }
}
