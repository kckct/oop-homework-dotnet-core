using Newtonsoft.Json.Linq;
using System.IO;

namespace Services
{
    /// <summary>
    /// Json 管理
    /// </summary>
    public abstract class JsonManager
    {
        /// <summary>
        /// 讀取 json 檔取得 JObject
        /// </summary>
        /// <param name="filePath">檔案路徑</param>
        /// <returns>JObject</returns>
        protected JObject GetJsonObject(string filePath)
        {
            // 讀取 json 檔
            string json = File.ReadAllText(filePath);

            // json parse
            return JObject.Parse(json);
        }

        /// <summary>
        /// 將 json 設定檔處理成可讓外部使用的 array
        /// </summary>
        public abstract void ProcessJsonConfig();
    }
}
