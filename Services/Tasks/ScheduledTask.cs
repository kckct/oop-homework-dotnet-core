using Candidates;
using System;
using System.Globalization;

namespace Services.Tasks
{
    /// <summary>
    /// ScheduledTask 排程備份
    /// </summary>
    public class ScheduledTask : AbstractTask
    {
        /// <summary>
        /// 每天
        /// </summary>
        const string INTERVAL_EVERYDAY = "EVERYDAY";

        /// <summary>
        /// 執行排程備份
        /// </summary>
        /// <param name="config">Config 物件</param>
        /// <param name="schedule">Schedule 物件</param>
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);

            // 取 Schedule 內設定的時間 interval
            string scheduleInterval = schedule.Interval.ToUpper();

            // 取 今天 interval
            string todayInterval = DateTime.Now.ToString("dddd", CultureInfo.CreateSpecificCulture("en-US")).ToUpper();

            // 1. interval 設定為 Everyday 的不檢查
            // 2. interval 設定與現在不同則中斷
            if (scheduleInterval != INTERVAL_EVERYDAY && (scheduleInterval != todayInterval))
            {
                return;
            }

            // 取 Schedule 內設定的時間 time
            DateTime scheduleTime = DateTime.Parse(schedule.Time);

            // 取 今天 time
            DateTime todayTime = DateTime.Now;

            // hour & minute 設定與現在不同則中斷
            if (scheduleTime.Hour != todayTime.Hour || scheduleTime.Minute != todayTime.Minute)
            {
                return;
            }

            // 找到檔案的所有 handlers 後進行處理
            foreach (Candidate candidate in fileFinder)
            {
                BroadcastToHandlers(candidate);
            }
        }
    }
}
