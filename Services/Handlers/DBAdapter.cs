using Candidates;

namespace Services.Handlers
{
    /// <summary>
    /// DBAdapter 資料庫介接
    /// </summary>
    public class DBAdapter : AbstractHandler
    {
        /// <summary>
        /// 處理檔案
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        /// <returns>byte[]</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            base.Perform(candidate, target);

            // 將備份檔存入 DB
            SaveBackupToDB(candidate, target);

            // 將 Log 存入 DB
            SaveLogToDB(candidate, target);

            return target;
        }

        /// <summary>
        /// 將備份檔存入 DB
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        private void SaveBackupToDB(Candidate candidate, byte[] target)
        {
            DBBackupHandler backupHandler = new DBBackupHandler();
            backupHandler.Perform(candidate, target);
        }

        /// <summary>
        /// 將 Log 存入 DB
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">byte[]</param>
        private void SaveLogToDB(Candidate candidate, byte[] target)
        {
            DBLogHandler logHandler = new DBLogHandler();
            logHandler.Perform(candidate, target);
        }
    }
}
