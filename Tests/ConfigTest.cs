using Newtonsoft.Json.Linq;
using Services;
using Xunit;

namespace Tests
{
    /// <summary>
    /// Config 測試
    /// </summary>
    public class ConfigTest
    {
        [Fact]
        public void json檔config有設定但沒有欄位_預設屬性字串為null布林為false()
        {
            // arrange
            JObject inputStub = JObject.Parse(@"{'configs':[{}]}");

            // act
            Config config = new Config(inputStub["configs"][0]);

            // assert
            Assert.Null(config.ConnectionString);
            Assert.Null(config.Destination);
            Assert.Null(config.Dir);
            Assert.Null(config.Ext);
            Assert.Null(config.Handlers);
            Assert.Null(config.Location);
            Assert.False(config.Remove);
            Assert.False(config.SubDirectory);
            Assert.Null(config.Unit);
        }

        [Fact]
        public void json檔config有設定有欄位_預設屬性正常()
        {
            // arrange
            JObject inputStub = JObject.Parse(@"{'configs':[{'connectionString':'xxx','destination':'directory','dir':'c:\\aaa','ext':'cs','handlers':['zip'],'location':'c:\\bbb','remove':false,'subDirectory':true,'unit':'file'}]}");

            // act
            Config config = new Config(inputStub["configs"][0]);

            // assert
            Assert.Equal("xxx", config.ConnectionString);
            Assert.Equal("directory", config.Destination);
            Assert.Equal("c:\\aaa", config.Dir);
            Assert.Equal("cs", config.Ext);
            Assert.Equal("zip", config.Handlers[0]);
            Assert.Equal("c:\\bbb", config.Location);
            Assert.False(config.Remove);
            Assert.True(config.SubDirectory);
            Assert.Equal("file", config.Unit);
        }
    }
}
