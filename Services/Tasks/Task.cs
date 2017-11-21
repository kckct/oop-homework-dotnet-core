namespace Services.Tasks
{
    /// <summary>
    /// Task interface
    /// </summary>
    public interface Task
    {
        /// <summary>
        /// 執行工作
        /// </summary>
        /// <param name="config">Config 物件</param>
        /// <param name="schedule">Schedule 物件</param>
        void Execute(Config config, Schedule schedule);
    }
}
