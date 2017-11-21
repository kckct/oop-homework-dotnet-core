using Candidates;
using System.IO;

namespace Services.Handlers
{
    /// <summary>
    /// FileHandler 檔案處理
    /// </summary>
    public class FileHandler : AbstractHandler
    {
        /// <summary>
        /// 檔案處理過後存放路徑
        /// </summary>
        const string FILEPATH = "D:\\Projects\\oop-homework\\storage\\app\\";

        /// <summary>
        /// 處理檔案
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        /// <returns>byte[]</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            base.Perform(candidate, target);

            // byte[] 為空時 將檔案轉成 byte[] 並回傳
            if (target == null)
            {
                return ConvertFileToByteArray(candidate);
            }

            // 將 byte[] 轉成檔案
            ConvertByteArrayToFile(candidate, target);
            return target;
        }

        /// <summary>
        /// 將檔案轉成 byte[]
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <returns>byte[]</returns>
        private byte[] ConvertFileToByteArray(Candidate candidate)
        {
            return File.ReadAllBytes(candidate.Name);
        }

        /// <summary>
        /// 將 byte[] 轉成檔案
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        private void ConvertByteArrayToFile(Candidate candidate, byte[] target)
        {
            // 檔案處理過後絕對路徑
            string backupFilePath = FILEPATH + Path.GetFileName(candidate.Name) + ".backup";
            File.WriteAllBytes(backupFilePath, target);
        }
    }
}
