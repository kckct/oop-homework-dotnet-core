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
        /// Config 物件
        /// </summary>
        public Config Config { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}