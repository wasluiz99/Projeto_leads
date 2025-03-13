using ProjetoLeads.Repositorios;

namespace ProjetoLeads.Services
{
    public class LeadsService
    {
        public RepositorioLeads RepositorioLeads { get; set; }

        public LeadsService()
        {
            RepositorioLeads = new RepositorioLeads();
        }
    }
}
