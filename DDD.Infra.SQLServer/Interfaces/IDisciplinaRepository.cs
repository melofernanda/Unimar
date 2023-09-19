using DDD.Unimar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IDisciplinaRepository
    {
        public List<Disciplina> GetDisciplinas();
        public Disciplina GetDisciplina(int id);
        public void InsertDisciplina(Disciplina disciplina); //Create
        public void UpdateDisciplina(Disciplina disciplina); //Update
        public void DeleteDisciplina(Disciplina disciplina); //Delete

        void AdicionarDisciplinaAAluno(int disciplinaId, int alunoId);
    }
}
