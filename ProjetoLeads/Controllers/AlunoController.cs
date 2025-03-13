using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using ProjetoLeads.Interfaces;
using ProjetoLeads.Models;
using ProjetoLeads.Services;

namespace ProjetoLeads.Controllers
{
    public class AlunoController : Controller
    {
        private TurmasService _turmaService = new TurmasService();
        private AlunoService _alunoService = new AlunoService();
        private readonly TesteContext _context;

        public AlunoController(TesteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MatricularAluno(int id)
        {
            try
            {

                var alunoLead = _context.Leads.FirstOrDefault(x => x.Id == id);
                if (alunoLead == null)
                {
                    return View();
                }

                var curso = _context.Cursos.FirstOrDefault(c => c.Id == alunoLead.CursoInteresse);
                if (curso == null)
                {
                    return View(); 
                }

                var turmasDoBanco = _context.Turmas
                    .Where(t => t.CursoId == alunoLead.CursoInteresse)
                    .OrderBy(t => t.Descricao)
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.Descricao
                    })
                    .ToList();

                if (turmasDoBanco.Count <= 0)
                {
                    return View();
                }

                ViewBag.ListTurma = turmasDoBanco;

                AlunoVm aluno = new AlunoVm()
                {
                    Nome = alunoLead.Nome,
                    Telefone = alunoLead.Telefone,
                    Email = alunoLead.Email,
                    CursoDescricao = curso.Descricao,
                    CursoId = (int)curso.Id,
                };

                return View(aluno);
            }
            catch (Exception ex)
            {

                return View(ex);
            }

        }

        [HttpPost]
        public IActionResult MatricularAluno(AlunoVm alunoVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
  

            try
            {
                int ultimoCodigo = _context.Alunos
                    .OrderByDescending(a => a.CodigoMatricula)
                    .Select(a => a.CodigoMatricula)
                    .FirstOrDefault();
                

                var aluno = new Aluno
                {
                    CodigoMatricula = ultimoCodigo + 1,
                    Nome = alunoVm.Nome,
                    Telefone = alunoVm.Telefone,
                    Email = alunoVm.Email,
                    CursoId = alunoVm.CursoId,
                    TurmaId = alunoVm.TurmaId,
                    DataCadastro = DateTime.Now,
                };

                _alunoService.RepositorioAluno.Create(aluno);

                TempData["MensagemSucesso"] = "Cadastro concluído com sucesso!";

                return RedirectToAction("ConsultaLeadsAll", "Leads");
            }
            catch(Exception ex)
            {
                return View(ex);
            }
            

        }

        public IActionResult ConsultaAlunosAll()
        {
            IEnumerable<Aluno> AlunoList = _alunoService.RepositorioAluno.GetAll();
            return View(AlunoList);
        }

        public IActionResult DeletarAluno(int id)
        {

            _alunoService.RepositorioAluno.DeleteById(id);
            return RedirectToAction("ConsultaAlunosAll");
        }

    }
}
