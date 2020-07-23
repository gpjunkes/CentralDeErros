using CentralDeErros.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralDeErros.Dados.Map
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Ambiente)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Level)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Titulo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Data)
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(8000)")
                .IsRequired();

            builder.Property(p => p.Origem)
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
