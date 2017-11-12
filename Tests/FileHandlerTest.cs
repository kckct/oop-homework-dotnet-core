using Newtonsoft.Json.Linq;
using Services;
using Services.Handlers;
using System;
using System.IO;
using Xunit;

namespace Tests
{
    /// <summary>
    /// FileHandler 測試
    /// </summary>
    public class FileHandlerTest
    {
        private FileHandler fileHandler;

        public FileHandlerTest()
        {
            fileHandler = new FileHandler();
        }

        [Fact]
        public void Test_將檔案轉成byte陣列_檔案不存在應丟exception()
        {
            // arrange
            Candidate candidateStub = new Candidate(null, null, null, null, null);
            byte[] targetStub = null;

            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => fileHandler.Perform(candidateStub, targetStub));
        }

        [Fact]
        public void Test_將檔案轉成byte陣列_byte陣列筆數應大於0()
        {
            // 測試 1.將檔案轉成byte陣列
            // arrange
            // 產生測試用檔案
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\test.txt";
            File.WriteAllText(filePath, "123");
            Assert.True(File.Exists(filePath));

            // 產生假 Candidate 物件
            Candidate candidateStub = CreateFakeCandidate();
            byte[] targetStub = null;

            // act
            byte[] actual = fileHandler.Perform(candidateStub, targetStub);

            // assert
            Assert.True(actual.Length > 0);

            // 測試結束刪除檔案
            File.Delete(filePath);
            Assert.False(File.Exists(filePath));

            // 測試 2.將byte陣列轉成檔案
            // arrange
            string backupFilePath = "D:\\Projects\\oop-homework\\storage\\app\\test.txt.backup";
            byte[] targetStub2 = actual;

            // act
            fileHandler.Perform(candidateStub, targetStub2);

            // assert
            // 查看是否有檔案產生
            Assert.True(File.Exists(backupFilePath));

            // 測試結束刪除檔案
            File.Delete(backupFilePath);
            Assert.False(File.Exists(backupFilePath));
        }

        private Candidate CreateFakeCandidate()
        {
            JObject inputStub = JObject.Parse(@"{'configs':[{'connectionString':'xxx','destination':'directory','dir':'c:\\aaa','ext':'cs','handlers':['zip'],'location':'c:\\bbb','remove':false,'subDirectory':true,'unit':'file'}]}");

            Config configStub = new Config(inputStub["configs"][0]);
            Candidate candidateStub = new Candidate(
                configStub, 
                "2017-11-12 12:34:56", 
                "D:\\Projects\\oop-homework\\storage\\app\\test.txt", 
                "xxx", 
                "123"
            );

            return candidateStub;
        }
    }
}
