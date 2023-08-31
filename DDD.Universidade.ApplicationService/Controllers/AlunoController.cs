using DDD.Infra.MemoryDb.Interfaces;
using DDD.Unimar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Universidade.ApplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        readonly IAlunoRepository  _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public ActionResult<List<Aluno>> Get()
        {
            return Ok(_alunoRepository.GetAlunos());
        }

        [HttpGet("{id}")]

        public ActionResult<Aluno> GetById(int id)
        {
            return Ok(_alunoRepository.GetAluno(id));
        }

        [HttpPost]

        public ActionResult<Aluno> CreateAluno(Aluno aluno) 
        {
            //Validação
            if (aluno.Nome.Length < 3 || aluno.Nome.Length > 30) 
            {
                return BadRequest("Nome não pode ser menor que 3 ou maior que 30 caracteres");
            }

            _alunoRepository.InsertAluno(aluno);
            return CreatedAtAction(nameof(GetById), new {id = aluno.Id}, aluno);
        }


        [HttpPut]

        public ActionResult<Aluno> Update([FromBody]Aluno aluno)
        {
            try
            {
                if (aluno == null)
                {
                    return BadRequest();
                }
                _alunoRepository.UpdateAluno(aluno);
                return Ok("Aluno atualizado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete]

        public ActionResult Delete([FromBody] Aluno aluno)
        {
            try
            {
                if (aluno == null)
                {
                    return BadRequest();
                }
                _alunoRepository.DeleteAluno(aluno);
                return Ok("Aluno deletado com sucesso");
            }
            catch (Exception)
            {
                throw;
            }
            

            
        }
        
        
    }
}
