using Services;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace Tests
{
    /// <summary>
    /// MyBackupService 測試
    /// </summary>
    public class MyBackupServiceTest
    {
        private MyBackupService myBackupService;

        public MyBackupServiceTest()
        {
            myBackupService = new MyBackupService(new ConfigManager(), new ScheduleManager());
        }

        [Fact]
        public void Test_執行處理json設定檔後private欄位managers型態正確()
        {
            // act
            // 取得 MyBackupService private field managers
            FieldInfo fieldInfo = myBackupService.GetType().GetField("managers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            List<JsonManager> managers = (List<JsonManager>)fieldInfo.GetValue(myBackupService);

            // assert
            // managers[0] 應為 ConfigManager
            Assert.IsType<ConfigManager>(managers[0]);
            // managers[1] 應為 ScheduleManager
            Assert.IsType<ScheduleManager>(managers[1]);
        }

        [Fact]
        public void Test_執行備份SimpleBackup_應會產生三個檔案()
        {
            // arrange
            // 產生測試用檔案
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\MyBackupServiceTest.txt";
            File.WriteAllText(filePath, "123");
            // 測試執行時預期產生的檔案
            string byteArrayToFile = "D:\\Projects\\oop-homework\\storage\\app\\MyBackupServiceTest.txt.backup";
            // 測試完預期產生的檔案
            string copyToNewFile = "D:\\Projects\\oop-homework\\storage\\app\\backup\\MyBackupServiceTest.txt.backup";

            // act
            myBackupService.SimpleBackup();

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
        public void Test_執行備份ScheduledBackup_應會產生一個檔案_不應有備份檔案()
        {
            // arrange
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\MyBackupServiceTest.txt2";
            File.WriteAllText(filePath, "123");
            // 測試執行時預期產生的檔案
            string byteArrayToFile = "D:\\Projects\\oop-homework\\storage\\app\\MyBackupServiceTest.txt2.backup";
            // 測試完預期產生的檔案
            string copyToNewFile = "D:\\Projects\\oop-homework\\storage\\app\\backup\\MyBackupServiceTest.txt2.backup";


            // act
            myBackupService.ScheduledBackup();

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
