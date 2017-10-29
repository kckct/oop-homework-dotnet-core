using Services;
using Xunit;

namespace Tests
{
    /// <summary>
    /// ConfigManager 測試
    /// </summary>
    public class ConfigManagerTest
    {
        [Fact]
        public void 讀取設定檔後屬性型態及筆數正確()
        {
            // act
            ConfigManager configManager = new ConfigManager();
            configManager.ProcessConfigs();

            // assert
            // 是否為 Config 型態
            Assert.IsType<Config>(configManager[0]);
            // 是否為 3 筆
            Assert.Equal(3, configManager.Count);
        }
    }
}
