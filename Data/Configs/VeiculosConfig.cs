using ApiCentralPark.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiCentralPark.Database.Configs
{
    public class VeiculosConfig : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("VEICULOS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Placa).HasMaxLength(8).IsRequired();
            builder.Property(x => x.HoraEntrada).IsRequired();
            builder.Property(x => x.valor).HasColumnType("money");

        }
    }
}