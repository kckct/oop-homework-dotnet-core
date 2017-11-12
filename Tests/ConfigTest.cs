using Newtonsoft.Json.Linq;
using Services;
using Xunit;

namespace Tests
{
    /// <summary>
    /// Config ����
    /// </summary>
    public class ConfigTest
    {
        [Fact]
        public void json��config���]�w���S�����_�w�]�ݩʦr�ꬰnull���L��false()
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
        public void json��config���]�w�����_�w�]�ݩʥ��`()
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
