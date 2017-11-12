using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Services.Files
{
    class LocalFileFinder : AbstractFileFinder
    {
        public LocalFileFinder()
        {
        }

        public LocalFileFinder(Config config) : base(config)
        {
            // 是否處理子目錄
            if (config.SubDirectory)
            {
                // 取得所有子目錄所有的檔名
                files = GetSubDirectoryFiles(config);
            }
            else
            {
                // 取得此目錄所有的檔名
                files = Directory.GetFiles(config.Location, "*." + config.Ext);
            }
        }

        private string[] GetSubDirectoryFiles(Config config)
        {
            List<string> allFiles = new List<string>();
            string[] subdirectoryEntries = Directory.GetDirectories(config.Location);
            foreach (string subdirectory in subdirectoryEntries)
            {
                allFiles.Add(Directory.GetFiles(subdirectory, "*." + config.Ext));
            }
        }

        protected override Candidate CreateCandidate(string fileName)
        {

        }
    }
}
