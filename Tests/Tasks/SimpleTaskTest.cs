using Newtonsoft.Json.Linq;
using Services;
using Services.Tasks;
using System.IO;
using Xunit;

namespace Tests.Tasks
{
    /// <summary>
    /// SimpleTask 測試
    /// </summary>
    public class SimpleTaskTest
    {
        [Fact]
        public void Test_執行簡單備份_應會產生三個檔案()
        {
            // arrange
            // 產生測試用檔案
            string filePath = "D:\\Projects\\oop-homework\\storage\\app\\SimpleTaskTest.txt5";
            File.WriteAllText(filePath, "123");
            // 測試執行時預期產生的檔案
            string byteArrayToFile = "D:\\Projects\\oop-homework\\storage\\app\\SimpleTaskTest.txt5.backup";
            // 測試完預期產生的檔案
            string copyToNewFile = "D:\\Projects\\oop-homework\\storage\\app\\backup\\SimpleTaskTest.txt5.backup";

            // act
            JObject inputStub = JObject.Parse(@"{'configs':[{'connectionString':'','destination':'directory','dir':'D:\\Projects\\oop-homework\\storage\\app\\backup','ext':'txt5','handlers':['zip', 'encode'],'location':'D:\\Projects\\oop-homework\\storage\\app','remove':false,'subDirectory':false,'unit':'file'}]}");
            Config configStub = new Config(inputStub["configs"][0]);
            SimpleTask simpleTask = new SimpleTask();
            simpleTask.Execute(configStub, null);

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
    }
}
