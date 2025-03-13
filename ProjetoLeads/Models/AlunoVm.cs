using System.ComponentModel;

namespace ProjetoLeads.Models
{
    public class AlunoVm
    {
        public int Id { get; set; }
        [DisplayName("Nº Matricula")]
        public int CodigoMatricula { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        public int CursoId { get; set; }
        [DisplayName("Curso")]
        public string CursoDescricao { get; set; }
        [DisplayName("Turma")]
        public int TurmaId { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
