using System.IO;

namespace Services.Files
{
    class LocalFileFinder : AbstractFileFinder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">Config 設定檔物件</param>
        public LocalFileFinder(Config config) : base(config)
        {
            // 取得此目錄所有的檔名參數
            SearchOption option = SearchOption.TopDirectoryOnly;

            // 是否處理子目錄
            if (config.SubDirectory)
            {
                // 取得所有子目錄所有的檔名參數
                option = SearchOption.AllDirectories;
            }

            // 依照參數取得檔名
            files = Directory.GetFiles(config.Location, "*." + config.Ext, option);
        }

        /// <summary>
        /// 產生 Candidate object
        /// </summary>
        /// <param name="fileName">檔名</param>
        /// <returns>Candidate object</returns>
        protected override Candidate CreateCandidate(string fileName)
        {
            // 取得檔案資訊
            FileInfo info = new FileInfo(fileName);

            return new Candidate(config, info.CreationTime, fileName, "processName", info.Length);
        }
    }
}
