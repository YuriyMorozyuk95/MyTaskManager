using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using Microsoft.Data.Entity;



namespace MyClassLibarary.BackEnd.SQLEntityConnection
{
    public class DateContext : DbContext
    {
        public DbSet<MyTask> MyTasks { get; set; }
        public DbSet<TaskTree> TaskTree { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyTaskTreeDB.db");
        }
    }

}
