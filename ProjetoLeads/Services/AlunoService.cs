using ProjetoLeads.Repositorios;

namespace ProjetoLeads.Services
{
    public class AlunoService
    {
        public RepositorioAluno RepositorioAluno { get; set; }

        public AlunoService()
        {
            RepositorioAluno = new RepositorioAluno();
        }
    }
}
