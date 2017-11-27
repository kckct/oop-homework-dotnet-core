using System;

namespace Services.Models
{
    /// <summary>
    /// MyLog model
    /// </summary>
    public class MyLog
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 檔名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 資料庫連接字串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 儲存目的地
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// 處理後的目錄
        /// </summary>
        public string Dir { get; set; }

        /// <summary>
        /// 檔案格式
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// 處理方式
        /// </summary>
        public string Handlers { get; set; }

        /// <summary>
        /// 備份檔案的目錄
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 處理完是否刪除檔案
        /// </summary>
        public bool Remove { get; set; }

        /// <summary>
        /// 是否處理子目錄
        /// </summary>
        public bool SubDirectory { get; set; }

        /// <summary>
        /// 備份單位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}