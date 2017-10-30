using Newtonsoft.Json.Linq;
using Services;
using Xunit;

namespace Tests
{
    /// <summary>
    /// Schedule ����
    /// </summary>
    public class ScheduleTest
    {
        [Fact]
        public void json��schedule���]�w���S�����_�w�]�ݩʦr�ꬰnull()
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
        public void json��schedule���]�w�����_�w�]�ݩʥ��`()
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
