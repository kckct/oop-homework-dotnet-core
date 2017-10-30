using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// Schedule 管理
    /// </summary>
    public class ScheduleManager : JsonManager
    {
        /// <summary>
        /// schedule.json 檔案路徑
        /// </summary>
        const string FILEPATH = @"D:\\Projects\\oop-homework-dotnet-core\\Services\\configs\\schedule.json";

        /// <summary>
        /// Schedule List
        /// </summary>
        private readonly List<Schedule> schedules = new List<Schedule>();

        /// <summary>
        /// 以 index 方式讀取物件屬性
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>schedules[index]</returns>
        public Schedule this[int index] => schedules[index];

        /// <summary>
        /// 筆數
        /// </summary>
        public int Count => schedules.Count;

        /// <summary>
        /// 處理 schedule.json 設定檔
        /// </summary>
        public override void ProcessJsonConfig()
        {
            // 讀取 json 檔取得 JObject
            JObject obj = GetJsonObject(FILEPATH);

            // 整理成 Schedule 放到 schedules
            foreach (JToken schedule in obj["schedules"])
            {
                schedules.Add(new Schedule(schedule));
            }
        }
    }
}
