using Newtonsoft.Json.Linq;
using Services;
using Candidates;
using Services.Handlers;
using System;
using Xunit;

namespace Tests.Handlers
{
    /// <summary>
    /// ZipHandler 測試
    /// </summary>
    class ZipHandlerTest
    {
        private ZipHandler zipHandler;

        public ZipHandlerTest()
        {
            zipHandler = new ZipHandler();
        }

        [Fact]
        public void Test_將byte陣列進行壓縮_傳入target有值_應回傳byte陣列且有值()
        {
            // arrange
            // 產生假 Candidate 物件
            Candidate candidateStub = CreateFakeCandidate();
            byte[] targetStub = new byte[1];

            // act
            byte[] actual = zipHandler.Perform(candidateStub, targetStub);

            // assert
            Assert.True(actual.Length > 0);
        }

        [Fact]
        public void Test_將byte陣列進行壓縮_傳入target為空陣列_應回傳空陣列()
        {
            // arrange
            // 產生假 Candidate 物件
            Candidate candidateStub = CreateFakeCandidate();
            byte[] targetStub = null;

            // act
            byte[] actual = zipHandler.Perform(candidateStub, targetStub);

            // assert
            Assert.Null(actual);
        }

        /// <summary>
        /// 產生假 Candidate 物件
        /// </summary>
        /// <returns>Candidate 物件</returns>
        private Candidate CreateFakeCandidate()
        {
            JObject inputStub = JObject.Parse(@"{'configs':[{'connectionString':'xxx','destination':'directory','dir':'c:\\aaa','ext':'cs','handlers':['zip'],'location':'c:\\bbb','remove':false,'subDirectory':true,'unit':'file'}]}");

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
