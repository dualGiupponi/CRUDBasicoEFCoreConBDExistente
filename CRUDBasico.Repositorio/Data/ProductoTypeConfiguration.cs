using CRUDBasico.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDBasico.Repositorio.Data
{
    internal class ProductoTypeConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            _ = builder.ToTable("productos_crudbasico")
                .HasKey(p => p.ID);

            _ = builder.Property(p => p.ID)
                .HasColumnName("pcb_id")
                .HasColumnType("SERIAL")
                .ValueGeneratedOnAdd();

            _ = builder.Property(p => p.Nombre)
                .HasColumnName("pcb_nom")
                .HasColumnType("VARCHAR(50)");

            _ = builder.Property(p => p.Descripcion)
                .HasColumnName("pcb_des")
                .HasColumnType("VARCHAR(150)");

            _ = builder.Property(p => p.Precio)
                .HasColumnName("pcb_pre")
                .HasColumnType("NUMERIC(1000, 2)");

            _ = builder.Property(p => p.Stock)
                .HasColumnName("pcb_stk")
                .HasColumnType("SMALLINT");

            _ = builder.Property(p => p.FechaAlta)
                .HasColumnName("pcb_fec_alt")
                .HasColumnType("TIMESTAMP")
                .HasValueGenerator<DateTimeGenerator>();

            _ = builder.Property(p => p.FechaActualizacion)
                .HasColumnName("pcb_fec_act")
                .HasColumnType("TIMESTAMP");

            _ = builder.Property(p => p.FechaBaja)
                .HasColumnName("pcb_fec_baj")
                .HasColumnType("TIMESTAMP");

            // Relaciones
            _ = builder.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey("pcb_id_ccb"); // Shadow Property
        }
    }
}
