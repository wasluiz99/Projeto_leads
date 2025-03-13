using ProjetoLeads.Interfaces;
using ProjetoLeads.Models;

namespace ProjetoLeads.Repositorios
{
    public class RepositorioLeads : RepositorioGeral<Lead>, ILeads
    {
        public RepositorioLeads(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
