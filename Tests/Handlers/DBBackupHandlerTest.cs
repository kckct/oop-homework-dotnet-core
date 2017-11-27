using Candidates;
using Newtonsoft.Json.Linq;
using Services;
using Services.Handlers;
using Services.Models;
using System;
using System.Linq;
using Xunit;

namespace Tests.Handlers
{
    /// <summary>
    /// DBBackupHandler 測試
    /// </summary>
    public class DBBackupHandlerTest
    {
        private DBBackupHandler backupHandler;

        public DBBackupHandlerTest()
        {
            backupHandler = new DBBackupHandler();
        }

        [Fact]
        public void Test_傳入candidate及target_應寫入資料庫MyBackup()
        {
            // arrange
            // 產生假 Candidate 物件
            Candidate candidateStub = CreateFakeCandidate();
            byte[] targetStub = new byte[1];

            // act
            byte[] actual = backupHandler.Perform(candidateStub, targetStub);

            // assert
            using (MyDbContext db = new MyDbContext())
            {
                string testName = "D:\\Projects\\oop-homework\\storage\\app\\DBBackupHandlerTest.txt";

                // 撈 MyBackup 應該有 1 筆符合的資料
                int myBackupNum = db.MyBackup.Where(b => b.Name == testName).Count();
                Assert.Equal(1, myBackupNum);

                // 刪除 MyBackup 測試資料
                var del = db.MyBackup.Where(b => b.Name == testName);
                db.MyBackup.RemoveRange(del);
                db.SaveChanges();

                // 撈 MyBackup 應該有 0 筆符合的資料
                int myBackupNum2 = db.MyBackup.Where(b => b.Name == testName).Count();
                Assert.Equal(0, myBackupNum2);
            }
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
                "D:\\Projects\\oop-homework\\storage\\app\\DBBackupHandlerTest.txt",
                "xxx",
                123
            );

            return candidateStub;
        }
    }
}
