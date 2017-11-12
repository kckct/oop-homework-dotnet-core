using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// Config 設定
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 資料庫連接字串
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// 儲存目的地
        /// </summary>
        public string Destination { get; }

        /// <summary>
        /// 處理後的目錄
        /// </summary>
        public string Dir { get; }

        /// <summary>
        /// 檔案格式
        /// </summary>
        public string Ext { get; }

        /// <summary>
        /// 處理方式
        /// </summary>
        public List<string> Handlers { get; }

        /// <summary>
        /// 備份檔案的目錄
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// 處理完是否刪除檔案
        /// </summary>
        public bool Remove { get; }

        /// <summary>
        /// 是否處理子目錄
        /// </summary>
        public bool SubDirectory { get; }

        /// <summary>
        /// 備份單位
        /// </summary>
        public string Unit { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">設定物件</param>
        public Config(JToken config)
        {
            ConnectionString = (string)config["connectionString"];
            Destination = (string)config["destination"];
            Dir = (string)config["dir"];
            Ext = (string)config["ext"];
            Handlers = (config["handlers"] == null) ? null : config["handlers"].ToObject<List<string>>();
            Location = (string)config["location"];
            Remove = (bool)(config["remove"] ?? "false");
            SubDirectory = (bool)(config["subDirectory"] ?? "false");
            Unit = (string)config["unit"];
        }
    }
}
