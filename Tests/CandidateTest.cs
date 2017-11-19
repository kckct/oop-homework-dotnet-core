using Candidates;
using Newtonsoft.Json.Linq;
using Services;
using System;
using Xunit;

namespace Tests
{
    public class CandidateTest
    {
        [Fact]
        public void Test_傳入null有預設屬性()
        {
            // act
            Candidate candidate = CandidateFactory.Create(null, new DateTime(), null, null, 0);

            // assert
            // Candidate 有屬性
            Assert.Null(candidate.Config);
            Assert.IsType<DateTime>(candidate.FileDateTime);
            Assert.Null(candidate.Name);
            Assert.Null(candidate.ProcessName);
            Assert.Equal(0, candidate.Size);
        }

        [Fact]
        public void Test_json檔config有設定有欄位_預設屬性正常()
        {
            // arrange
            JObject inputStub = JObject.Parse(@"{'configs':[{'connectionString':'xxx','destination':'directory','dir':'c:\\aaa','ext':'cs','handlers':['zip'],'location':'c:\\bbb','remove':false,'subDirectory':true,'unit':'file'}]}");

            // act
            Config configStub = new Config(inputStub["configs"][0]);
            Candidate candidate = CandidateFactory.Create(configStub, Convert.ToDateTime("2017-11-12 12:34:56"), "c:\\test.txt", "xxx", 123);

            // assert
            // Candidate 的屬性 config 型別應為 Config
            Assert.IsType<Config>(candidate.Config);
            // Candidate 屬性值是否正確
            Assert.IsType<DateTime>(candidate.FileDateTime);
            Assert.Equal("c:\\test.txt", candidate.Name);
            Assert.Equal("xxx", candidate.ProcessName);
            Assert.Equal(123, candidate.Size);
        }
    }
}
