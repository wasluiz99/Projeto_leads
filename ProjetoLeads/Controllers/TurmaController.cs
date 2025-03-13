using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoLeads.Models;
using ProjetoLeads.Services;

namespace ProjetoLeads.Controllers
{
    public class TurmaController : Controller
    {
        private TurmasService _turmaService = new TurmasService();
        private AlunoService _alunoService = new AlunoService();
        private CursosService _cursosService = new CursosService();
        private readonly TesteContext _context;

        public TurmaController(TesteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CadastrarTurma()
        {
            ConfiguarViewBagCursos();

            return View();
        }

        [HttpPost]
        public IActionResult CadastrarTurma(Turma turma)
        {
            ConfiguarViewBagCursos();

            _turmaService.RepositorioTurmas.Create(turma);

            TempData["MensagemSucesso"] = "Cadastro concluído com sucesso!";

            return RedirectToAction("CadastrarTurma");
        }

        public IActionResult ConfiguarViewBagCursos()
        {
            IEnumerable<Curso> cursoList = _cursosService.RepositorioCursos.GetAll();

            var cursosDoBanco = cursoList
            .OrderBy(c => c.Descricao)
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Descricao
            })
            .ToList();

            ViewBag.ListCursos = cursosDoBanco;

            return View();
        }
    }
}
