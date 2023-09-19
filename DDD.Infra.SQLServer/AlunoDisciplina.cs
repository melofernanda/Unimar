using DDD.Unimar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DDD.Infra.SQLServer
{

    public class AlunoDisciplina
    {
        [Key]
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [Key]
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

    }
}