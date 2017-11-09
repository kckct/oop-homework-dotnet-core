using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
            string jsonString = File.ReadAllText(FILEPATH);
            handlerDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        }

        /// <summary>
        ///  建立對應的 Handler object
        /// </summary>
        /// <param name="key">handler key</param>
        /// <returns>Handler object</returns>
        public static Handler Create(string key)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == key);
            return (Handler)Activator.CreateInstance(currentType);
        }
    }
}
