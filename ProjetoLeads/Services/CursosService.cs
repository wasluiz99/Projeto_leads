using ProjetoLeads.Repositorios;

namespace ProjetoLeads.Services
{
    public class CursosService
    {
        public RepositorioCursos RepositorioCursos { get; set; }

        public CursosService()
        {
            RepositorioCursos = new RepositorioCursos();
        }
    }
}
