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
    }
}
