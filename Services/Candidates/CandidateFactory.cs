using Services;
using System;

namespace Candidates
{
    /// <summary>
    /// CandidateFactory Candidate 物件工廠
    /// </summary>
    public class CandidateFactory
    {
        /// <summary>
        /// 建立 Candidate 物件
        /// </summary>
        /// <param name="config">Config 物件</param>
        /// <param name="fileDateTime">檔案的日期與時間</param>
        /// <param name="name">檔案名稱</param>
        /// <param name="processName">處理檔案的 process</param>
        /// <param name="size">檔案 size</param>
        /// <returns>Candidate 物件</returns>
        public static Candidate Create(Config config, DateTime creationTime, string fileName, string processName, long size)
        {
            return new Candidate(config, creationTime, fileName, processName, size);
        }
    }
}
