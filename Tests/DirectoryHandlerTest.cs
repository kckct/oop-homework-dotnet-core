using Newtonsoft.Json.Linq;
using Services;
using Candidates;
using Services.Handlers;
using System;
using System.IO;
using Xunit;

namespace Tests
{
    /// <summary>
    /// DirectoryHandler 測試
    /// </summary>
    public class DirectoryHandlerTest
    {
        private DirectoryHandler directoryHandler;

        public DirectoryHandlerTest()
        {
            directoryHandler = new DirectoryHandler();
        }

        [Fact]
        public void Test_將byte陣列還原成檔案並複製到其他目錄_傳入target有值_應複製檔案()
        {
            // arrange
            // 測試執行時預期產生的檔案
            string byteArrayToFile = "D:\\Projects\\oop-homework\\storage\\app\\test.txt.backup";
            // 測試完預期產生的檔案
            string copyToNewFile = "D:\\Projects\\oop-homework\\storage\\app\\backup\\test.txt.backup";

            // 產生假 Candidate 物件
            Candidate candidateStub = CreateFakeCandidate();
            byte[] targetStub = new byte[1];

            // act
            byte[] actual = directoryHandler.Perform(candidateStub, targetStub);

            // assert
            // 查看是否有檔案產生
            Assert.True(File.Exists(byteArrayToFile));
            Assert.True(File.Exists(copyToNewFile));

            // 測試結束刪除檔案
            File.Delete(byteArrayToFile);
            File.Delete(copyToNewFile);
            Assert.False(File.Exists(byteArrayToFile));
            Assert.False(File.Exists(copyToNewFile));
        }

        [Fact]
        public void Test_將byte陣列還原成檔案並複製到其他目錄_傳入target為空陣列_應回傳空陣列()
        {
            // arrange
            // 產生假 Candidate 物件
            Candidate candidateStub = CreateFakeCandidate();
            byte[] targetStub = null;

            // act
            byte[] actual = directoryHandler.Perform(candidateStub, targetStub);

            // assert
            Assert.Null(actual);
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
                "D:\\Projects\\oop-homework\\storage\\app\\test.txt",
                "xxx",
                123
            );

            return candidateStub;
        }
    }
}
