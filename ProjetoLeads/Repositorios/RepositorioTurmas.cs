using ProjetoLeads.Interfaces;
using ProjetoLeads.Models;

namespace ProjetoLeads.Repositorios
{
    public class RepositorioTurmas : RepositorioGeral<Turma>, ITurmas
    {
        public RepositorioTurmas(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
