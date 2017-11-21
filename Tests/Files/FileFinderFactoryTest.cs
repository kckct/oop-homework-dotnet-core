using Candidates;
using Newtonsoft.Json.Linq;
using Services;
using Services.Files;
using System.IO;
using Xunit;

namespace Tests.Files
{
    /// <summary>
    /// HandlerFactory 測試
    /// </summary>
    public class FileFinderFactoryTest
    {
        [Fact]
        public void Test_傳入尚未無法對應的key_應回傳null()
        {
            // assert
            Assert.Null(FileFinderFactory.Create("xxx", null));
        }

        [Fact]
        public void Test_傳入config_不處理子目錄_應回傳1筆LocalFileFinder物件且可使用foreach方式存取()
        {
            // arragne
            // 產生測試用檔案, 目前目錄
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\FileFinderFactoryTest.txt3";
            File.WriteAllText(filePath, "123");
            // 產生測試用檔案, 目前目錄下子目錄
            string filePath2 = "D:\\Projects\\oop-homework\\storage\\app\\public\\FileFinderFactoryTest2.txt3";
            File.WriteAllText(filePath2, "123");

            JObject inputStub = JObject.Parse(@"{'configs':[{'connectionString':'','destination':'directory','dir':'D:\\Projects\\oop-homework\\storage\\app\\backup','ext':'txt3','handlers':['zip', 'encode'],'location':'D:\\Projects\\oop-homework\\storage\\app','remove':false,'subDirectory':false,'unit':'file'}]}");

            Config configStub = new Config(inputStub["configs"][0]);

            // act
            FileFinder fileFinder = FileFinderFactory.Create("file", configStub);

            // assert
            // 查看是否有檔案產生
            Assert.True(File.Exists(filePath));
            Assert.True(File.Exists(filePath2));
            // 型別應為 FileFinder
            Assert.IsAssignableFrom<FileFinder>(fileFinder);
            // 以 array 方式存取時 型別應為 Candidate
            int count = 0;
            foreach (var finder in fileFinder)
            {
                Assert.IsType<Candidate>(finder);
                count++;
            }
            // FileFinder 筆數應為 1
            Assert.Equal(1, count);
            // 測試結束刪除檔案
            File.Delete(filePath);
            File.Delete(filePath2);
            Assert.False(File.Exists(filePath));
            Assert.False(File.Exists(filePath2));
        }

        [Fact]
        public void Test_傳入config_處理子目錄_應回傳2筆LocalFileFinder物件且可使用foreach方式存取()
        {
            // arragne
            // 產生測試用檔案, 目前目錄
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\FileFinderFactoryTest.txt4";
            File.WriteAllText(filePath, "123");
            // 產生測試用檔案, 目前目錄下子目錄
            string filePath2 = "D:\\Projects\\oop-homework\\storage\\app\\public\\FileFinderFactoryTest2.txt4";
            File.WriteAllText(filePath2, "123");

            JObject inputStub = JObject.Parse(@"{'configs':[{'connectionString':'','destination':'directory','dir':'D:\\Projects\\oop-homework\\storage\\app\\backup','ext':'txt4','handlers':['zip', 'encode'],'location':'D:\\Projects\\oop-homework\\storage\\app','remove':false,'subDirectory':true,'unit':'file'}]}");

            Config configStub = new Config(inputStub["configs"][0]);

            // act
            FileFinder fileFinder = FileFinderFactory.Create("file", configStub);

            // assert
            // 查看是否有檔案產生
            Assert.True(File.Exists(filePath));
            Assert.True(File.Exists(filePath2));
            // 型別應為 FileFinder
            Assert.IsAssignableFrom<FileFinder>(fileFinder);
            // 以 array 方式存取時 型別應為 Candidate
            int count = 0;
            foreach (var finder in fileFinder)
            {
                Assert.IsType<Candidate>(finder);
                count++;
            }
            // FileFinder 筆數應為 2
            Assert.Equal(2, count);
            // 測試結束刪除檔案
            File.Delete(filePath);
            File.Delete(filePath2);
            Assert.False(File.Exists(filePath));
            Assert.False(File.Exists(filePath2));
        }
    }
}
