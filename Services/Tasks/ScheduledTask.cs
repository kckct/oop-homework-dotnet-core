namespace Services.Tasks
{
    /// <summary>
    /// ScheduledTask 排程備份
    /// </summary>
    public class ScheduledTask : AbstractTask
    {
        /// <summary>
        /// 執行排程備份
        /// </summary>
        /// <param name="config">Config 物件</param>
        /// <param name="schedule">Schedule 物件</param>
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);

            // 取 Schedule 內設定的時間 interval

            // 取 今天 interval

            // 1. interval 設定為 Everyday 的不檢查
            // 2. interval 設定與現在不同則中斷

            // 取 Schedule 內設定的時間 time 並切為時與分

            // 取 今天 time

            // hour & minute 設定與現在不同則中斷

            // 找到檔案的所有 handlers 後進行處理
            foreach (Candidate candidate in fileFinder)
            {
                BroadcastToHandlers(candidate);
            }
        }
    }
}
