using Newtonsoft.Json.Linq;
using Services;
using Xunit;

namespace Tests
{
    /// <summary>
    /// Schedule 測試
    /// </summary>
    public class ScheduleTest
    {
        [Fact]
        public void json檔schedule有設定但沒有欄位_預設屬性字串為null()
        {
            // arrange
            JObject inputStub = JObject.Parse(@"{'schedules':[{}]}");

            // act
            Schedule schedule = new Schedule(inputStub["schedules"][0]);

            // assert
            Assert.Null(schedule.Ext);
            Assert.Null(schedule.Interval);
            Assert.Null(schedule.Time);
        }

        [Fact]
        public void json檔schedule有設定有欄位_預設屬性正常()
        {
            // arrange
            JObject inputStub = JObject.Parse(@"{'schedules':[{'ext':'cs','time':'12:34','interval':'XXXDay'}]}");

            // act
            Schedule schedule = new Schedule(inputStub["schedules"][0]);

            // assert
            Assert.Equal("cs", schedule.Ext);
            Assert.Equal("12:34", schedule.Time);
            Assert.Equal("XXXDay", schedule.Interval);
        }
    }
}
