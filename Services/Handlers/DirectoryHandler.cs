using Candidates;
using System.IO;

namespace Services.Handlers
{
    /// <summary>
    /// DirectoryHandler 檔案複製
    /// </summary>
    public class DirectoryHandler : AbstractHandler
    {
        /// <summary>
        /// 處理檔案
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        /// <returns>byte[]</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            base.Perform(candidate, target);

            // byte[] 為空時 直接回傳
            if (target == null)
            {
                return target;
            }

            // 將 byte[] 還原檔案並複製到其他目錄
            CopyToDirectory(candidate, target);

            return target;
        }

        /// <summary>
        /// 還原檔案並複製到其他目錄
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        private void CopyToDirectory(Candidate candidate, byte[] target)
        {
            // 還原檔案
            FileHandler fileHandler = new FileHandler();
            fileHandler.Perform(candidate, target);

            // 原檔案路徑
            string oldFilePath = candidate.Name + ".backup";

            // 檔名
            string backupFileName = Path.GetFileName(oldFilePath);

            // config.json 內所設定的 dir 目錄
            string newDir = candidate.Config.Dir;

            // 複製後的檔案路徑
            string newFilePath = newDir + Path.DirectorySeparatorChar + backupFileName;

            // 複製檔案
            File.Copy(oldFilePath, newFilePath);
        }
    }
}
