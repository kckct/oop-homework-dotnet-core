namespace Services.Handler
{
    /// <summary>
    /// Handler interface
    /// </summary>
    public interface Handler
    {
        /// <summary>
        /// 處理檔案
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        /// <returns>byte[]</returns>
        byte[] Perform(Candidate candidate, byte[] target);
    }
}