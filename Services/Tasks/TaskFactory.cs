namespace Services.Tasks
{
    /// <summary>
    /// TaskFactory Task 工廠
    /// </summary>
    public static class TaskFactory
    {
        /// <summary>
        /// 建立對應的 Task 物件
        /// </summary>
        /// <param name="task">task key</param>
        /// <returns>Task 物件</returns>
        public static Task Create(string task)
        {
            if (task == "simple")
            {
                return new SimpleTask();
            }
            else if (task == "scheduled")
            {
                return new ScheduledTask();
            }

            return null;
        }
    }
}
