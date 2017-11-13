using Services.Files;
using Services.Handlers;
using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// MyBackupService
    /// </summary>
    public class MyBackupService
    {
        /// <summary>
        /// JsonManager List
        /// </summary>
        private readonly List<JsonManager> managers = new List<JsonManager>();

        /// <summary>
        /// Constructor
        /// </summary>
        public MyBackupService()
        {
            managers.Add(new ConfigManager());
            managers.Add(new ScheduleManager());
        }

        /// <summary>
        /// 處理 json 設定檔
        /// </summary>
        public void ProcessJsonConfigs()
        {
            foreach (JsonManager manager in managers)
            {
                manager.ProcessJsonConfig();
            }
        }

        /// <summary>
        /// 執行備份
        /// </summary>
        public void DoBackup()
        {
            // 取得 ConfigManager
            ConfigManager configManager = GetConfigManager();

            for (int i = 0; i < configManager.Count; i++)
            {
                // 找檔案
                FileFinder fileFinder = FileFinderFactory.Create("file", configManager[i]);

                // 找到檔案的所有 handlers 後進行處理
                foreach (Candidate candidate in fileFinder)
                {
                    BroadcastToHandlers(candidate);
                }
            }
        }

        /// <summary>
        /// 取得 ConfigManager
        /// </summary>
        /// <returns>ConfigManager 物件</returns>
        private ConfigManager GetConfigManager()
        {
            foreach (JsonManager manager in managers)
            {
                if (manager.GetType() == typeof(ConfigManager))
                {
                    return (ConfigManager)manager;
                }
            }

            return null;
        }

        /// <summary>
        /// 找到檔案的所有 handlers 後進行處理
        /// </summary>
        /// <param name="candidate">Candidate 物件</param>
        private void BroadcastToHandlers(Candidate candidate)
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
