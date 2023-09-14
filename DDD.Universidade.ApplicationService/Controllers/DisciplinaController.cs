using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;
using DDD.Unimar.Domain.Entities;
using DDD.Universidade.ApplicationService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DDD.Universidade.ApplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        readonly IDisciplinaRepository _disciplinaRepository;
        private object _alunoRepository;
        private object _context;

        public DisciplinaController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        [HttpGet]
        public ActionResult<List<Disciplina>> Get()
        {
            return Ok(_disciplinaRepository.GetDisciplinas());
        }

        [HttpGet("{id}")]

        public ActionResult<Disciplina> GetById(int id)
        {
            return Ok(_disciplinaRepository.GetDisciplina(id));
        }

        [HttpPost]

        public ActionResult<Disciplina> CreateDisciplina(Disciplina disciplina)
        {
            //Validação
            if (disciplina.Nome.Length < 3 || disciplina.Nome.Length > 30)
            {
                return BadRequest("Nome não pode ser menor que 3 ou maior que 30 caracteres");
            }

            _disciplinaRepository.InsertDisciplina(disciplina);
            return CreatedAtAction(nameof(GetById), new { id = disciplina.Id }, disciplina);
        }

        [HttpPut]

        public ActionResult<Disciplina> Update([FromBody] Disciplina disciplina)
        {
            try
            {
                if (disciplina == null)
                {
                    return BadRequest();
                }
                _disciplinaRepository.UpdateDisciplina(disciplina);
                return Ok("Disciplina atualizado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]

        public ActionResult Delete([FromBody] Disciplina disciplina)
        {
            try
            {
                if (disciplina == null)
                {
                    return BadRequest();
                }
                _disciplinaRepository.DeleteDisciplina(disciplina);
                return Ok("Disciplina deletado com sucesso");
            }
            catch (Exception)
            {
                throw;
            }



        }
        [HttpPost("adicionar-disciplina-aluno")]
        public IActionResult AdicionarDisciplinaAAluno([FromBody] AdicionarDisciplinaAlunoRequest request)
        {
            try
            {
                _disciplinaRepository.AdicionarDisciplinaAAluno(request.DisciplinaId, request.AlunoId);
                return Ok("Disciplina associada ao aluno com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao associar a disciplina ao aluno: {ex.Message}");
            }
        }




    }
}
