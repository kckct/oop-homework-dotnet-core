using Microsoft.EntityFrameworkCore;

namespace Services.Models
{
    /// <summary>
    /// 資料庫設定
    /// </summary>
    public class MyDbContext : DbContext
    {
        /// <summary>
        /// 連線設定
        /// </summary>
        /// <param name="optionsBuilder">設定選項</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=D:\\Projects\\oop-homework-dotnet-core\\Services\\database.db");
        }

        public DbSet<MyBackup> MyBackup { get; set; }
        public DbSet<MyLog> MyLog { get; set; }

        /// <summary>
        /// 建立 Model 時的設定
        /// </summary>
        /// <param name="modelBuilder">model builder 設定</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyBackup>().ToTable("MyBackup");
            modelBuilder.Entity<MyLog>().ToTable("MyLog");
        }
    }
}