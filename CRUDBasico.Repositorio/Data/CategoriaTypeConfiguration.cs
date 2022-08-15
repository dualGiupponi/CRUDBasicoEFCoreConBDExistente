using CRUDBasico.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDBasico.Repositorio.Data
{
    internal class CategoriaTypeConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            _ = builder.ToTable("categorias_crudbasico")
                .HasKey(c => c.ID);

            _ = builder.Property(c => c.ID)
                .HasColumnName("ccb_id")
                .HasColumnType("SERIAL")
                .ValueGeneratedOnAdd();

            _ = builder.Property(c => c.Nombre)
                .HasColumnName("ccb_nom")
                .HasColumnType("VARCHAR(50)");

            _ = builder.Property(c => c.Descripcion)
                .HasColumnName("ccb_des")
                .HasColumnType("VARCHAR(150)");

            _ = builder.Property(c => c.FechaAlta)
                .HasColumnName("ccb_fec_alt")
                .HasColumnType("TIMESTAMP")
                .HasValueGenerator<DateTimeGenerator>();

            _ = builder.Property(c => c.FechaActualizacion)
                .HasColumnName("ccb_fec_act")
                .HasColumnType("TIMESTAMP");

            _ = builder.Property(c => c.FechaBaja)
                .HasColumnName("ccb_fec_baj")
                .HasColumnType("TIMESTAMP");
        }
    }
}
