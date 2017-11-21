using Candidates;
using System.IO;
using System.IO.Compression;

namespace Services.Handlers
{
    /// <summary>
    /// ZipHandler 檔案壓縮
    /// </summary>
    public class ZipHandler : AbstractHandler
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

            // 將 byte[] 壓縮
            return ZipData(candidate, target);
        }

        /// <summary>
        /// 壓縮
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        /// <returns>byte[]</returns>
        private byte[] ZipData(Candidate candidate, byte[] target)
        {
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(target, 0, target.Length);
            }
            return output.ToArray();
        }
    }
}
