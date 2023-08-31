using DDD.Unimar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Interfaces
{
    public interface IAlunoRepository
    {
        public List<Aluno> GetAlunos(); //Read
        public Aluno GetAluno(int id);
        public void InsertAluno(Aluno aluno); //Create
        public void UpdateAluno(Aluno aluno); //Update
        public void DeleteAluno(Aluno aluno); //Delete

    }
}
