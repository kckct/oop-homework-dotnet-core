using System;
using System.Collections.Generic;

namespace Services.Models
{
    /// <summary>
    /// MyBackup model
    /// </summary>
    public class MyBackup
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
        /// 檔案時間
        /// </summary>
        public DateTime FileDateTime { get; set; }

        /// <summary>
        /// 檔案大小
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// 資料處理
        /// </summary>
        public List<string> Handlers { get; set; }

        /// <summary>
        /// 檔案內容
        /// </summary>
        public Byte[] Target { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}