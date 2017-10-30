using Services;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Tests
{
    /// <summary>
    /// MyBackupService 測試
    /// </summary>
    public class MyBackupServiceTest
    {
        [Fact]
        public void 執行處理json設定檔後private欄位managers型態正確()
        {
            // act
            MyBackupService myBackupService = new MyBackupService();
            myBackupService.ProcessJsonConfigs();

            // 取得 MyBackupService private field managers
            FieldInfo fieldInfo = myBackupService.GetType().GetField("managers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            List<JsonManager> managers = (List<JsonManager>)fieldInfo.GetValue(myBackupService);

            // assert
            // managers[0] 應為 ConfigManager
            Assert.IsType<ConfigManager>(managers[0]);
            // managers[1] 應為 ScheduleManager
            Assert.IsType<ScheduleManager>(managers[1]);
        }
    }
}
