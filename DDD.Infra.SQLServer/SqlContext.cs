using DDD.Unimar.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Disciplina> Disciplinas { get; set; }

        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>()
                .HasKey(ad => new { ad.AlunoId, ad.DisciplinaId });
        }

    }
}
