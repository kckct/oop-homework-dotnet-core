using Candidates;
using Services.Models;
using System;

namespace Services.Handlers
{
    /// <summary>
    /// DBBackupHandler 檔案備份到資料庫
    /// </summary>
    public class DBBackupHandler : AbstractDBHandler
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

            using (MyDbContext db = new MyDbContext())
            {
                db.MyBackup.Add(new MyBackup {
                    Name = candidate.Name,
                    FileDateTime = candidate.FileDateTime,
                    Size = candidate.Size,
                    Handlers = candidate.Config.Handlers.ToString(),
                    Target = target,
                    CreatedAt = DateTime.Now
                });

                db.SaveChanges();
            }

            return target;
        }
    }
}
