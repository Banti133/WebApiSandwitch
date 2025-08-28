using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace WebApiSandwitch.Model
{
    public class SandwitchContext : DbContext
    {
        public SandwitchContext(DbContextOptions<SandwitchContext> options) : base(options)
        {
        }
        public DbSet<Sandwitch> Sandswitches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //Configuring DB connection
            
        }
    }
}
