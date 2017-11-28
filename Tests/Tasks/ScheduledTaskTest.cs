using Newtonsoft.Json.Linq;
using Services;
using Services.Tasks;
using System;
using System.IO;
using Xunit;

namespace Tests.Tasks
{
    /// <summary>
    /// ScheduledTask 測試
    /// </summary>
    public class ScheduledTaskTest
    {
        private ScheduledTask scheduledTask;

        public ScheduledTaskTest()
        {
            scheduledTask = new ScheduledTask();
        }

        [Fact]
        public void Test_執行排程備份_schedule設定為現在時間_應會產生三個檔案()
        {
            // arrange
            // 產生測試用檔案
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\ScheduledTaskTest.txt6";
            File.WriteAllText(filePath, "123");
            // 測試執行時預期產生的檔案
            string byteArrayToFile = "D:\\Projects\\oop-homework\\storage\\app\\ScheduledTaskTest.txt6.backup";
            // 測試完預期產生的檔案
            string copyToNewFile = "D:\\Projects\\oop-homework\\storage\\app\\backup\\ScheduledTaskTest.txt6.backup";

            // act
            scheduledTask.Execute(CreateFakeConfig(), CreateFakeScheduleCanExecute());

            // assert
            // 查看是否有檔案產生
            Assert.True(File.Exists(filePath));
            Assert.True(File.Exists(byteArrayToFile));
            Assert.True(File.Exists(copyToNewFile));

            // 測試結束刪除檔案
            File.Delete(filePath);
            File.Delete(byteArrayToFile);
            File.Delete(copyToNewFile);
            Assert.False(File.Exists(filePath));
            Assert.False(File.Exists(byteArrayToFile));
            Assert.False(File.Exists(copyToNewFile));
        }

        [Fact]
        public void Test_執行排程備份_schedule設定為現在時間加一小時_應會產生一個檔案()
        {
            // arrange
            // 產生測試用檔案
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\ScheduledTaskTest.txt6";
            File.WriteAllText(filePath, "123");
            // 測試執行時預期產生的檔案
            string byteArrayToFile = "D:\\Projects\\oop-homework\\storage\\app\\ScheduledTaskTest.txt6.backup";
            // 測試完預期產生的檔案
            string copyToNewFile = "D:\\Projects\\oop-homework\\storage\\app\\backup\\ScheduledTaskTest.txt6.backup";

            // act
            scheduledTask.Execute(CreateFakeConfig(), CreateFakeScheduleCanNotExecute());

            // assert
            // 查看是否有檔案產生
            Assert.True(File.Exists(filePath));

            // 測試結束刪除檔案
            File.Delete(filePath);
            Assert.False(File.Exists(filePath));
            Assert.False(File.Exists(byteArrayToFile));
            Assert.False(File.Exists(copyToNewFile));
        }

        /// <summary>
        /// 產生假 Config
        /// </summary>
        /// <returns>Config 物件</returns>
        private Config CreateFakeConfig()
        {
            JObject inputStub = JObject.Parse(@"{'configs':[{'connectionString':'','destination':'directory','dir':'D:\\Projects\\oop-homework\\storage\\app\\backup','ext':'txt6','handlers':['zip', 'encode'],'location':'D:\\Projects\\oop-homework\\storage\\app','remove':false,'subDirectory':false,'unit':'file'}]}");
            return new Config(inputStub["configs"][0]);
        }

        /// <summary>
        /// 產生假 Schedule 排程現在可執行
        /// </summary>
        /// <returns>Schedule 物件</returns>
        private Schedule CreateFakeScheduleCanExecute()
        {
            JObject inputStub = JObject.Parse(@"{'schedules':[{'ext':'txt6','interval':'Everyday','time':'" + DateTime.Now.ToString("HH:mm") + "'}]}");
            return new Schedule(inputStub["schedules"][0]);
        }

        /// <summary>
        /// 產生假 Schedule 排程現在不可執行
        /// </summary>
        /// <returns>Schedule 物件</returns>
        private Schedule CreateFakeScheduleCanNotExecute()
        {
            JObject inputStub = JObject.Parse(@"{'schedules':[{'ext':'txt6','interval':'Everyday','time':'" + DateTime.Now.AddHours(1).ToString("HH:mm") + "'}]}");
            return new Schedule(inputStub["schedules"][0]);
        }
    }
}
