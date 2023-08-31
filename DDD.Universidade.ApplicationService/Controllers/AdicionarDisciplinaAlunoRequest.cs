using System.Runtime.InteropServices;

namespace DDD.Universidade.ApplicationService.Models
{
    public class AdicionarDisciplinaAlunoRequest
    {
        public int DisciplinaId { get; set; }
        public int AlunoId { get; set; }
    }
}