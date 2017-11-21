using Newtonsoft.Json.Linq;
using Services;
using Services.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Tests.Tasks
{
    /// <summary>
    /// TaskDispatcher 測試
    /// </summary>
    class TaskDispatcherTest
    {
        private TaskDispatcher taskDispatcher;

        public TaskDispatcherTest()
        {
            taskDispatcher = new TaskDispatcher();
        }

        [Fact]
        public void Test_執行簡單備份的工作_應會產生三個檔案()
        {
            // arrange
            // 產生測試用檔案
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\TaskDispatcherTest.txt";
            File.WriteAllText(filePath, "123");
            // 測試執行時預期產生的檔案
            string byteArrayToFile = "D:\\Projects\\oop-homework\\storage\\app\\TaskDispatcherTest.txt.backup";
            // 測試完預期產生的檔案
            string copyToNewFile = "D:\\Projects\\oop-homework\\storage\\app\\backup\\TaskDispatcherTest.txt.backup";

            List<JsonManager> managersStub = new List<JsonManager>();
            ConfigManager configManagerStub = new ConfigManager();
            configManagerStub.ProcessJsonConfig();
            managersStub.Add(configManagerStub);

            // act
            taskDispatcher.SimpleTask(managersStub);

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
        public void Test_執行排程備份的工作_應會產生一個檔案()
        {
            // arrange
            // 產生測試用檔案
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\TaskDispatcherTest2.txt";
            File.WriteAllText(filePath, "123");
            // 測試執行時預期產生的檔案
            string byteArrayToFile = "D:\\Projects\\oop-homework\\storage\\app\\TaskDispatcherTest2.txt.backup";
            // 測試完預期產生的檔案
            string copyToNewFile = "D:\\Projects\\oop-homework\\storage\\app\\backup\\TaskDispatcherTest2.txt.backup";

            List<JsonManager> managersStub = new List<JsonManager>();
            ConfigManager configManagerStub = new ConfigManager();
            configManagerStub.ProcessJsonConfig();
            managersStub.Add(configManagerStub);

            ScheduleManager scheduleManagerStub = new ScheduleManager();
            scheduleManagerStub.ProcessJsonConfig();
            managersStub.Add(scheduleManagerStub);

            // act
            taskDispatcher.ScheduledTask(managersStub);

            // assert
            // 查看是否有檔案產生
            Assert.True(File.Exists(filePath));

            // 測試結束刪除檔案
            File.Delete(filePath);
            Assert.False(File.Exists(filePath));
            Assert.False(File.Exists(byteArrayToFile));
            Assert.False(File.Exists(copyToNewFile));
        }
    }
}
