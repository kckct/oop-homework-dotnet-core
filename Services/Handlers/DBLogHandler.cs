using Candidates;
using Services.Models;
using System;

namespace Services.Handlers
{
    /// <summary>
    /// DBLogHandler 寫 Log 到資料庫
    /// </summary>
    public class DBLogHandler : AbstractDBHandler
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
                db.MyLog.Add(new MyLog {
                    Name = candidate.Name,
                    ConnectionString = candidate.Config.ConnectionString,
                    Destination = candidate.Config.Destination,
                    Dir = candidate.Config.Dir,
                    Ext = candidate.Config.Ext,
                    Handlers = candidate.Config.Handlers.ToString(),
                    Location = candidate.Config.Location,
                    Remove = candidate.Config.Remove,
                    SubDirectory = candidate.Config.SubDirectory,
                    Unit = candidate.Config.Unit,
                    CreatedAt = DateTime.Now
                });

                db.SaveChanges();
            }

            return target;
        }
    }
}
