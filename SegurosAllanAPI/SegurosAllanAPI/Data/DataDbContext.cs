using Microsoft.EntityFrameworkCore;
using SegurosAllanAPI.Models;

namespace SegurosAllanAPI.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<Segurado> Segurados { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Seguro> Seguros { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Segurado>()
        //        .HasKey(p => p.Cpf);
        //}

    }
}
