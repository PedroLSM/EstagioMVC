using EstagioMVC.Models;
using EstagioMVC.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstagioMVC.Controllers
{
    public class CursoController : Controller
    {
        private ApplicationDbContext ctx;

        public CursoController()
        {
            ctx = new ApplicationDbContext();
        }

        private List<Curso> ListaDeCursos()
        {
            var userId = User.Identity.GetUserId();
            return ctx.Cursos.Where(c => c.UserId == userId).ToList();
        }

        private Curso BuscarCurso(ViewModelCurso ViewCurso)
        {
            var userId = User.Identity.GetUserId();
            return ctx.Cursos.FirstOrDefault(c => c.Id == ViewCurso.IdCurso && c.User.Id == userId);
        }

        private Curso BuscarCurso(int Id)
        {
            var userId = User.Identity.GetUserId();
            return ctx.Cursos.FirstOrDefault(c => c.Id == Id && c.User.Id == userId);
        }

        // Controladora para Exibir
        [Authorize]
        public ActionResult Exibir()
        {
            var cursos = ListaDeCursos();

            return View(cursos);
        }

        // Controladoras para Adicionar
        [Authorize]
        public ActionResult Adicionar()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(ViewModelCurso ViewCurso)
        {

            if (!ModelState.IsValid)
            {
                return View("Adicionar", ViewCurso);
            }

            Curso curso = new Curso
            {
                Nome = ViewCurso.Nome,
                Autor = ViewCurso.Autor,
                CargaHoraria = ViewCurso.Carga,
                Classificacao = ViewCurso.Avaliacao,
                UserId = User.Identity.GetUserId()
            };

            ctx.Cursos.Add(curso);
            ctx.SaveChanges();

            return RedirectToAction("Exibir", "Curso");
        }

        // Controladoras para Atualizar
        [Authorize]
        public ActionResult Atualizar()
        {
            var ViewCurso = new ViewModelCurso
            {
                Cursos = ListaDeCursos()
            };

            return View(ViewCurso);
        }

        [Authorize]
        public ActionResult EditarDados(int Id)
        {
            Curso curso = BuscarCurso(Id);

            if (curso == null)
            {
                return RedirectToAction("Atualizar", "Curso");
            }

            ViewModelCurso ViewCurso = new ViewModelCurso
            {
                IdCurso = Id
            };

            ViewCurso.SetarCampos(curso, ListaDeCursos());

            return View(ViewCurso);

        }

        [Authorize]
        [HttpPost]
        public ActionResult EditarDados(ViewModelCurso ViewCurso)
        {
            Curso curso = BuscarCurso(ViewCurso);

            if (curso == null)
            {
                return RedirectToAction("Atualizar", "Curso");
            }

            ViewCurso.SetarCampos(curso, ListaDeCursos());

            return View(ViewCurso);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(ViewModelCurso ViewCurso)
        {
            Curso curso = BuscarCurso(ViewCurso);

            curso.Nome = ViewCurso.Nome;
            curso.Autor = ViewCurso.Autor;
            curso.CargaHoraria = ViewCurso.Carga;
            curso.Classificacao = ViewCurso.Avaliacao;

            ctx.SaveChanges();
            return RedirectToAction("Exibir", "Curso");

        }

        // Controladoras para Deletar
        [Authorize]
        public ActionResult Deletar()
        {
            ViewModelCurso cursos = new ViewModelCurso()
            {
                Cursos = ListaDeCursos()
            };

            return View(cursos);
        }

        [Authorize]
        public ActionResult Checar(int Id)
        {
            Curso curso = BuscarCurso(Id);

            if (curso == null)
            {
                return RedirectToAction("Exibir", "Curso");
            }

            ViewModelCurso ViewCurso = new ViewModelCurso
            {
                IdCurso = Id
            };

            ViewCurso.SetarCampos(curso, ListaDeCursos());

            return View(ViewCurso);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Checar(ViewModelCurso ViewCurso)
        {
            Curso curso = BuscarCurso(ViewCurso);

            if (curso == null)
            {
                return RedirectToAction("Deletar", "Curso");
            }

            ViewCurso.SetarCampos(curso, ListaDeCursos());

            return View(ViewCurso);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(ViewModelCurso ViewCurso)
        {
            Curso curso = BuscarCurso(ViewCurso);

            if (curso == null)
            {
                return RedirectToAction("Deletar", "Curso");
            }

            ctx.Cursos.Remove(curso);
            ctx.SaveChanges();

            return RedirectToAction("Exibir", "Curso");
        }

    }

}
