using Newtonsoft.Json.Linq;

namespace Services
{
    public class Candidate
    {
        /// <summary>
        /// Config 物件
        /// </summary>
        public Config Config { get; }

        /// <summary>
        /// 檔案的日期與時間
        /// </summary>
        public string FileDateTime { get; }

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 處理檔案的 process
        /// </summary>
        public string ProcessName { get; }

        /// <summary>
        /// 檔案 size
        /// </summary>
        public string Size { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="candidate">設定物件</param>
        public Candidate(JToken candidate)
        {
            Config = candidate["config"].ToObject<Config>();
            FileDateTime = (string)candidate["fileDateTime"];
            Name = (string)candidate["name"];
            ProcessName = (string)candidate["processName"];
            Size = (string)candidate["size"];
        }
    }
}
