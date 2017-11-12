﻿using Newtonsoft.Json.Linq;

namespace Services
{
    public class Candidate
    {
        /// <summary>
        /// Config 物件
        /// </summary>
        public Config Config { get; }

        /// <summary>
        /// 檔案的日期與時間
        /// </summary>
        public string FileDateTime { get; }

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 處理檔案的 process
        /// </summary>
        public string ProcessName { get; }

        /// <summary>
        /// 檔案 size
        /// </summary>
        public string Size { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">Config 物件</param>
        /// <param name="fileDateTime">檔案的日期與時間</param>
        /// <param name="name">檔案名稱</param>
        /// <param name="processName">處理檔案的 process</param>
        /// <param name="size">檔案 size</param>
        public Candidate(Config config, string fileDateTime, string name, string processName, string size)
        {
            Config = config;
            FileDateTime = fileDateTime;
            Name = name;
            ProcessName = processName;
            Size = size;
        }
    }
}
