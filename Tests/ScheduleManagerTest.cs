using Services;
using Xunit;

namespace Tests
{
    /// <summary>
    /// ScheduleManager 測試
    /// </summary>
    public class ScheduleManagerTest
    {
        [Fact]
        public void Test_讀取設定檔後屬性型態及筆數正確()
        {
            // act
            ScheduleManager scheduleManager = new ScheduleManager();
            scheduleManager.ProcessJsonConfig();

            // assert
            // 是否為 Schedule 型態
            Assert.IsType<Schedule>(scheduleManager[0]);
            // 是否為 3 筆
            Assert.Equal(3, scheduleManager.Count);
        }
    }
}
