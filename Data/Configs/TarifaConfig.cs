using ApiCentralPark.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiCentralPark.Data.Configs
{
    public class TarifaConfig : IEntityTypeConfiguration<Tarifa>
    {
        public void Configure(EntityTypeBuilder<Tarifa> builder)
        {
            builder.ToTable("TARIFAS");
            builder.Property(x => x.ValorTarifa).HasColumnType("money");
            builder.Property(x => x.ValorAdicional).HasColumnType("money");
            builder.Property(x => x.QuantidadeDeVagas);

            builder.HasData(new List<Tarifa>()
            {
                new Tarifa()
                {
                    Id= 1,
                    ValorTarifa=1,
                    ValorAdicional=1,
                    QuantidadeDeVagas=1,

                }
            });
        }

    }
}




