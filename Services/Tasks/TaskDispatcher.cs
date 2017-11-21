using System.Collections.Generic;

namespace Services.Tasks
{
    /// <summary>
    /// TaskDispatcher 工作分配
    /// </summary>
    public class TaskDispatcher
    {
        /// <summary>
        /// Task 物件
        /// </summary>
        private Task task;

        /// <summary>
        /// 簡單備份的工作
        /// </summary>
        /// <param name="managers">JsonManager List</param>
        public void SimpleTask(List<JsonManager> managers)
        {
            // 建立簡單備份工作的物件
            task = TaskFactory.Create("simple");

            // 取得 ConfigManager
            ConfigManager configManager = GetConfigManager(managers);

            // 以 config.json 設定檔內容去執行工作
            for (int i = 0; i < configManager.Count; i++)
            {
                task.Execute(configManager[i], null);
            }
        }

        /// <summary>
        /// 取得 ConfigManager
        /// </summary>
        /// <returns>ConfigManager 物件</returns>
        private ConfigManager GetConfigManager(List<JsonManager> managers)
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
        /// 排程備份的工作
        /// </summary>
        /// <param name="managers">JsonManager List</param>
        public void ScheduledTask(List<JsonManager> managers)
        {
            // 建立簡單備份工作的物件
            task = TaskFactory.Create("scheduled");

            // 取得 ConfigManager
            ConfigManager configManager = GetConfigManager(managers);

            // 取得 ScheduleManager
            ScheduleManager scheduleManager = GetScheduleManager(managers);

            // Schedule 設定要處理的檔案類型必須在 Config 內也有設定才執行備份
            for (int i = 0; i < configManager.Count; i++)
            {
                for (int j = 0; j < scheduleManager.Count; j++)
                {
                    if (configManager[i].Ext == scheduleManager[j].Ext)
                    {
                        task.Execute(configManager[i], scheduleManager[j]);
                    }
                }
            }
        }

        /// <summary>
        /// 取得 ScheduleManager
        /// </summary>
        /// <returns>ScheduleManager 物件</returns>
        private ScheduleManager GetScheduleManager(List<JsonManager> managers)
        {
            foreach (JsonManager manager in managers)
            {
                if (manager.GetType() == typeof(ScheduleManager))
                {
                    return (ScheduleManager)manager;
                }
            }

            return null;
        }
    }
}
