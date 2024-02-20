using Microsoft.EntityFrameworkCore;
using ProiectOptDezAplWeb.Models;

namespace ProiectOptDezAplWeb.Data
{
    public class ProiectContext: DbContext
    {
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Materials> Materialss { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public ProiectContext(DbContextOptions<ProiectContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
