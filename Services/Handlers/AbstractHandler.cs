using Candidates;

namespace Services.Handlers
{
    /// <summary>
    /// 抽象類別 AbstractHandler
    /// </summary>
    public class AbstractHandler : Handler
    {
        /// <summary>
        /// 處理檔案
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        /// <returns>byte[]</returns>
        public virtual byte[] Perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}
