namespace Services.Tasks
{
    /// <summary>
    /// SimpleTask 簡單備份
    /// </summary>
    public class SimpleTask : AbstractTask
    {
        /// <summary>
        /// 執行簡單備份
        /// </summary>
        /// <param name="config">Config 物件</param>
        /// <param name="schedule">Schedule 物件</param>
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);

            // 找到檔案的所有 handlers 後進行處理
            foreach (Candidate candidate in fileFinder)
            {
                BroadcastToHandlers(candidate);
            }
        }
    }
}
