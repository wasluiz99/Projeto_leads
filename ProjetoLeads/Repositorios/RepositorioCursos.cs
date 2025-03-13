using ProjetoLeads.Interfaces;
using ProjetoLeads.Models;

namespace ProjetoLeads.Repositorios
{
    public class RepositorioCursos : RepositorioGeral<Curso>, ICursos
    {
        public RepositorioCursos(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
