using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoLeads.Interfaces;
using ProjetoLeads.Models;
using ProjetoLeads.Services;

namespace ProjetoLeads.Controllers
{
    public class LeadsController : Controller
    {
        private LeadsService _leadService = new LeadsService();
        private CursosService _cursosService = new CursosService();
        private readonly TesteContext _context;

        public LeadsController(TesteContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult ConsultaLeads()
        {
            ConfiguarViewBagCursos();
            return View();
        }

        [HttpPost]
        public IActionResult ResultadoConsultaLeads(Lead leads)
        {
            var query = _context.Leads.AsQueryable();

            if (!string.IsNullOrEmpty(leads.Nome))
            {
                query = query.Where(a => a.Nome.Contains(leads.Nome));
            }

            if (!string.IsNullOrEmpty(leads.Email))
            {
                query = query.Where(a => a.Email.Contains(leads.Email));
            }

            if (leads.CursoInteresse > 0)
            {
                query = query.Where(a => a.CursoInteresse == leads.CursoInteresse);
            }

            var resultados = query.ToList();
            return View("ResultadoConsultaLeads", resultados);
        }

        [HttpGet]
        public IActionResult ConsultaLeadsAll()
        {
            IEnumerable<Lead> leadList = _leadService.RepositorioLeads.GetAll();
            return View(leadList);
        }

        [HttpGet]
        public IActionResult CadastroLeads()
        {
            ConfiguarViewBagCursos();

            return View();
        }

        [HttpPost]
        public IActionResult CadastroLeads(Lead lead)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ConfiguarViewBagCursos();

            _leadService.RepositorioLeads.Create(lead);

            TempData["MensagemSucesso"] = "Cadastro concluído com sucesso!";

            return RedirectToAction("CadastroLeads");
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


        public IActionResult DeletarLeadAll(int id)
        {

            _leadService.RepositorioLeads.DeleteById(id);
            return RedirectToAction("ConsultaLeadsAll");
        }

        public IActionResult DeletarLead(int id)
        {

            _leadService.RepositorioLeads.DeleteById(id);
            return RedirectToAction("ConsultaLeadsAll");
        }
    }
}
