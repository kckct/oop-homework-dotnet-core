using Services.Handlers;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    /// <summary>
    /// HandlerFactory 測試
    /// </summary>
    public class HandlerFactoryTest
    {
        [Fact]
        public void Test_傳入尚未設定的key_丟出exception()
        {
            // assert
            Assert.Throws<KeyNotFoundException>(() => HandlerFactory.Create("xxx"));
        }

        [Fact]
        public void Test_傳入file_回傳FileHandler物件()
        {
            // assert
            Assert.IsType<FileHandler>(HandlerFactory.Create("file"));
        }

        [Fact]
        public void Test_傳入encode_回傳EncodeHandler物件()
        {
            // assert
            Assert.IsType<EncodeHandler>(HandlerFactory.Create("encode"));
        }

        [Fact]
        public void Test_傳入zip_回傳ZipHandler物件()
        {
            // assert
            Assert.IsType<ZipHandler>(HandlerFactory.Create("zip"));
        }

        [Fact]
        public void Test_傳入directory_回傳DirectoryHandler物件()
        {
            // assert
            Assert.IsType<DirectoryHandler>(HandlerFactory.Create("directory"));
        }
    }
}
