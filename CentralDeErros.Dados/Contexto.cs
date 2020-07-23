using CentralDeErros.Dados.Map;
using CentralDeErros.Dominio.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Dados
{
    public class Contexto : IdentityDbContext
    {
        public DbSet<Evento> Evento { get; set; }
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EventoMap());
        }

    }
}
