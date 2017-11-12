using System;
using System.Text;

namespace Services.Handlers
{
    /// <summary>
    /// EncodeHandler 檔案加密
    /// </summary>
    public class EncodeHandler : AbstractHandler
    {
        /// <summary>
        /// 加密處理
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

            // 將 byte[] 加密
            return Encoding.Default.GetBytes(Convert.ToBase64String(target));
        }
    }
}
