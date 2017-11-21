using Candidates;
using Services.Files;
using Services.Handlers;
using System.Collections.Generic;

namespace Services.Tasks
{
    /// <summary>
    /// 抽象類別 AbstractTask
    /// </summary>
    public abstract class AbstractTask : Task
    {
        /// <summary>
        /// FileFinder 物件
        /// </summary>
        protected FileFinder fileFinder;

        /// <summary>
        /// 執行工作
        /// </summary>
        /// <param name="config">Config 物件</param>
        /// <param name="schedule">Schedule 物件</param>
        public virtual void Execute(Config config, Schedule schedule)
        {
            // 建立 file 的 FileFinder
            fileFinder = FileFinderFactory.Create("file", config);
        }

        /// <summary>
        /// 找到檔案的所有 handlers 後進行處理
        /// </summary>
        /// <param name="candidate">Candidate 物件</param>
        protected void BroadcastToHandlers(Candidate candidate)
        {
            // 找到檔案的所有 handlers
            List<Handler> handlers = FindHandlers(candidate);

            // byte[]
            byte[] target = null;

            // 依不同的 handler 處理檔案
            foreach (Handler handler in handlers)
            {
                target = handler.Perform(candidate, target);
            }
        }

        /// <summary>
        /// 找到檔案的所有 handlers
        /// </summary>
        /// <param name="candidate">Candidate 物件</param>
        /// <returns>Handler 陣列</returns>
        private List<Handler> FindHandlers(Candidate candidate)
        {
            // 加入 處理檔案
            List<Handler> handlers = new List<Handler>
            {
                HandlerFactory.Create("file")
            };

            // 加入 config.json 內設定的 handler
            foreach (string handler in candidate.Config.Handlers)
            {
                handlers.Add(HandlerFactory.Create(handler));
            }

            // 加入 處理檔案儲存目的
            handlers.Add(HandlerFactory.Create(candidate.Config.Destination));

            return handlers;
        }
    }
}
