using Candidates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services;
using System;
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
        public void Test_執行備份SimpleBackup會執行四個Handler_應會產生三個檔案()
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
        public void Test_執行備份ScheduledBackup會執行四個Handler_應會產生三個檔案()
        {
            // arrange
            // 產生測試用檔案
            //string testJsonPath = @"D:\\Projects\\oop-homework-dotnet-core\\Services\\configs\\test-schedule.json";
            //var obj = new {
            //    schedules = new [] {
            //        new {
            //            ext = "txt",
            //            time = "12:00",
            //            interval = "Everyday",
            //        }
            //    }
            //};

            //string json = JsonConvert.SerializeObject(obj);
            //File.WriteAllText(testJsonPath, json);

            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\MyBackupServiceTest.txt2";
            File.WriteAllText(filePath, "123");
            // 測試執行時預期產生的檔案
            string byteArrayToFile = "D:\\Projects\\oop-homework\\storage\\app\\MyBackupServiceTest.txt2.backup";
            // 測試完預期產生的檔案
            string copyToNewFile = "D:\\Projects\\oop-homework\\storage\\app\\backup\\MyBackupServiceTest.txt2.backup";

            // 產生假 Candidate 物件
            Candidate candidateStub = CreateFakeCandidate();
            List<Candidate> listCandidate = new List<Candidate>
            {
                candidateStub
            };

            // act
            MyBackupService myBackupService = new MyBackupService(new ConfigManager(), CreateFakeScheduleManager());
            myBackupService.ScheduledBackup();

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

        /// <summary>
        /// 產生假 Candidate 物件
        /// </summary>
        /// <returns>Candidate 物件</returns>
        private Candidate CreateFakeCandidate()
        {
            JObject inputStub = JObject.Parse(@"{'configs':[{'connectionString':'','destination':'directory','dir':'D:\\Projects\\oop-homework\\storage\\app\\backup','ext':'txt','handlers':['zip', 'encode'],'location':'D:\\Projects\\oop-homework\\storage\\app','remove':false,'subDirectory':true,'unit':'file'}]}");

            Config configStub = new Config(inputStub["configs"][0]);
            Candidate candidateStub = CandidateFactory.Create(
                configStub,
                Convert.ToDateTime("2017-11-12 12:34:56"),
                "D:\\Projects\\oop-homework\\storage\\app\\MyBackupServiceTest.txt",
                "xxx",
                123
            );

            return candidateStub;
        }

        private ScheduleManager CreateFakeScheduleManager()
        {
            ScheduleManager scheduleManagerStub = new ScheduleManager();
            List<Schedule> fieldStub = new List<Schedule>();

            var jsonObj = new
            {
                schedules = new[] {
                    new {
                        ext = "txt",
                        time = DateTime.Now.ToString("HH:mm"),
                        interval = "Everyday",
                    }
                }
            };

            string json = JsonConvert.SerializeObject(jsonObj);

            // json parse
            JObject obj = JObject.Parse(json);
            //Console.WriteLine(obj);

            // 整理成 Schedule 放到 schedules
            foreach (JToken schedule in obj["schedules"])
            {
                fieldStub.Add(new Schedule(schedule));
            }

            FieldInfo fld = typeof(ScheduleManager).GetField("schedules", BindingFlags.Instance | BindingFlags.NonPublic);
            fld.SetValue(scheduleManagerStub, fieldStub);

            return scheduleManagerStub;
        }
    }
}
