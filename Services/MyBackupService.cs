using Services.Tasks;
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
        /// TaskDispatcher 工作分配
        /// </summary>
        private TaskDispatcher taskDispatcher;

        /// <summary>
        /// Constructor
        /// </summary>
        public MyBackupService()
        {
            managers.Add(new ConfigManager());
            managers.Add(new ScheduleManager());
            taskDispatcher = new TaskDispatcher();

            Init();
        }

        /// <summary>
        /// 初始化設定
        /// </summary>
        private void Init()
        {
            // 處理 json 設定檔
            ProcessJsonConfigs();
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
        /// 簡單備份
        /// </summary>
        public void SimpleBackup()
        {
            taskDispatcher.SimpleTask(managers);
        }

        /// <summary>
        /// 排程備份
        /// </summary>
        public void ScheduledBackup()
        {
            taskDispatcher.ScheduledTask(managers);
        }
    }
}
