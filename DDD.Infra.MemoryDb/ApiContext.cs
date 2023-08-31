using DDD.Unimar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.MemoryDb
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UniversidadeDb");
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }


    }
}