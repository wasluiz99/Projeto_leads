using ProjetoLeads.Interfaces;
using ProjetoLeads.Models;

namespace ProjetoLeads.Repositorios
{
    public class RepositorioAluno : RepositorioGeral<Aluno>, IAluno
    {
        public RepositorioAluno(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
