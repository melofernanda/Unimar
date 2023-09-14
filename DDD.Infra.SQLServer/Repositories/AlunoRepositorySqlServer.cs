using DDD.Infra.SQLServer.Interfaces;
using DDD.Unimar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class AlunoRepositorySqlServer : IAlunoRepository
    {
        private readonly SqlContext _context;

        public AlunoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public List<Aluno> GetAlunos()
        {


            var list = _context.Alunos.Include(x => x.Disciplinas).ToList();
            return list;

        }

        public Aluno GetAluno(int id)
        {
            return _context.Alunos.Find(id);
        }

        public void InsertAluno(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateAluno(Aluno aluno)
        {
            try
            {
                _context.Entry(aluno).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteAluno(Aluno aluno)
        {
            try
            {
                _context.Set<Aluno>().Remove(aluno);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
