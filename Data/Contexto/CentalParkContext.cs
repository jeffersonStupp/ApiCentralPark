using ApiCentralPark.Data.Configs;
using ApiCentralPark.Database.Configs;
using ApiCentralPark.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCentralPark.Database.Contexto
{
    public class CentalParkContext : DbContext
    {
        public DbSet<Pessoa> PESSOAS { get; set; }
        public DbSet<Usuario> USUARIOS { get; set; }
        public DbSet<Veiculo> VEICULOS { get; set; }
        public DbSet<Tarifa> TARIFAS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SJ1Q4M7\\SQLEXPRESS;Initial catalog=CENTRALPARK;Trusted_connection=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new VeiculosConfig());
            modelBuilder.ApplyConfiguration(new TarifaConfig());

        }
    }
}