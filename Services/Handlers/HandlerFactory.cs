using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Services.Handlers
{
    /// <summary>
    /// HandlerFactory
    /// </summary>
    public class HandlerFactory
    {
        /// <summary>
        /// config.json 檔案路徑
        /// </summary>
        const string FILEPATH = @"D:\\Projects\\oop-homework-dotnet-core\\Services\\configs\\handler_mapping.json";

        private static Dictionary<string, string> handlerDictionary;

        /// <summary>
        /// Constructor
        /// </summary>
        static HandlerFactory()
        {
            // 讀取 json 內容
            string jsonString = File.ReadAllText(FILEPATH);

            // 將 json 轉成 Dictionary
            handlerDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        }

        /// <summary>
        ///  建立對應的 Handler object
        /// </summary>
        /// <param name="key">handler key</param>
        /// <returns>Handler object</returns>
        public static Handler Create(string key)
        {
            // 組出完整 namespace
            string fullNameSpace = "Services.Handlers." + handlerDictionary[key];

            // 回傳產生的物件
            Type handler = Type.GetType(fullNameSpace);
            return (Handler)Activator.CreateInstance(handler);
        }
    }
}
