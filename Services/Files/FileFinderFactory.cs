namespace Services.Files
{
    public class FileFinderFactory
    {
        /// <summary>
        /// 建立對應的 FileFinder object
        /// </summary>
        /// <param name="finder">產生 FileFinder 的類型</param>
        /// <param name="config">Config 設定檔物件</param>
        /// <returns></returns>
        public static FileFinder Create(string finder, Config config)
        {
            if (finder == "file")
            {
                return new LocalFileFinder(config);
            }

            return null;
        }
    }
}
