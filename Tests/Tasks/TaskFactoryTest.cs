using Services.Tasks;
using Xunit;

namespace Tests.Tasks
{
    /// <summary>
    /// TaskFactoryTest 測試
    /// </summary>
    public class TaskFactoryTest
    {
        [Fact]
        public void Test_傳入尚未無法對應的key_應回傳null()
        {
            // assert
            Assert.Null(TaskFactory.Create("xxx"));
        }

        [Fact]
        public void Test_傳入simple_回傳SimpleTask物件()
        {
            // assert
            Assert.IsType<SimpleTask>(TaskFactory.Create("simple"));
        }

        [Fact]
        public void Test_傳入scheduled_回傳ScheduledTask物件()
        {
            // assert
            Assert.IsType<ScheduledTask>(TaskFactory.Create("scheduled"));
        }
    }
}
