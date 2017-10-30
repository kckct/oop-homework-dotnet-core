using Newtonsoft.Json.Linq;

namespace Services
{
    /// <summary>
    /// Schedule 設定
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// 排程所處理的檔案格式
        /// </summary>
        public string Ext { get; }

        /// <summary>
        /// 排程執行的間隔
        /// </summary>
        public string Interval { get; }

        /// <summary>
        /// 排程所處理的時間
        /// </summary>
        public string Time { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">設定物件</param>
        public Schedule(JToken config)
        {
            Ext = (string)config["ext"];
            Interval = (string)config["interval"];
            Time = (string)config["time"];
        }
    }
}
