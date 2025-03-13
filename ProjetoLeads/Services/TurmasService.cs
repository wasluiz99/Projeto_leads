using ProjetoLeads.Repositorios;

namespace ProjetoLeads.Services
{
    public class TurmasService
    {
        public RepositorioTurmas RepositorioTurmas { get; set; }

        public TurmasService()
        {
            RepositorioTurmas = new RepositorioTurmas();
        }
    }
}
