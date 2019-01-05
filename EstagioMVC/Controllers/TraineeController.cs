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
    public class TraineeController : Controller
    {

        private ApplicationDbContext ctx;

        public TraineeController()
        {
            ctx = new ApplicationDbContext();
        }

        private List<Trainee> ListaDeTrainees()
        {
            var userId = User.Identity.GetUserId();
            return ctx.Trainees.Where(c => c.UserId == userId).ToList();
        }

        private Trainee BuscarTrainee(ViewModelTrainee ViewTrainee)
        {
            var userId = User.Identity.GetUserId();
            return ctx.Trainees.FirstOrDefault(c => c.Id == ViewTrainee.IdTrainee && c.User.Id == userId);
        }

        private Trainee BuscarTrainee(int Id)
        {
            var userId = User.Identity.GetUserId();
            return ctx.Trainees.FirstOrDefault(c => c.Id == Id && c.User.Id == userId);
        }


        // Controladora para Exibir
        [Authorize]
        public ActionResult Exibir()
        {
            var trainees = ListaDeTrainees();

            return View(trainees);
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
        public ActionResult Adicionar(ViewModelTrainee ViewTrainee)
        {

            if (!ModelState.IsValid)
            {
                return View("Adicionar", ViewTrainee);
            }

            Trainee trainee = new Trainee
            {
                Nome = ViewTrainee.Nome,
                UserId = User.Identity.GetUserId()
            };

            trainee.Instituicao = ViewTrainee.Instituicao ?? "Não Cadastrado";

            ctx.Trainees.Add(trainee);
            ctx.SaveChanges();

            return RedirectToAction("Exibir", "Trainee");
        }

        // Controladoras para Atualizar
        [Authorize]
        public ActionResult Atualizar()
        {
            var ViewTrainee = new ViewModelTrainee
            {
                Trainees = ListaDeTrainees()
            };

            return View(ViewTrainee);
        }

        [Authorize]
        public ActionResult EditarDados(int Id)
        {
            Trainee curso = BuscarTrainee(Id);

            if (curso == null)
            {
                return RedirectToAction("Atualizar", "Trainee");
            }

            ViewModelTrainee ViewTrainee = new ViewModelTrainee
            {
                IdTrainee = Id
            };

            ViewTrainee.SetarCampos(curso, ListaDeTrainees());

            return View(ViewTrainee);

        }

        [Authorize]
        [HttpPost]
        public ActionResult EditarDados(ViewModelTrainee ViewTrainee)
        {
            Trainee trainee = BuscarTrainee(ViewTrainee);

            if (trainee == null)
            {
                return RedirectToAction("Atualizar", "Trainee");
            }

            ViewTrainee.SetarCampos(trainee, ListaDeTrainees());

            return View(ViewTrainee);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(ViewModelTrainee ViewTrainee)
        {
            Trainee trainee = BuscarTrainee(ViewTrainee);

            trainee.Nome = ViewTrainee.Nome;
            trainee.Instituicao = ViewTrainee.Instituicao ?? "Não Cadastrado";

            ctx.SaveChanges();
            return RedirectToAction("Exibir", "Trainee");

        }

        // Controladoras para Deletar
        [Authorize]
        public ActionResult Deletar()
        {
            ViewModelTrainee cursos = new ViewModelTrainee()
            {
                Trainees = ListaDeTrainees()
            };

            return View(cursos);
        }

        [Authorize]
        public ActionResult Checar(int Id)
        {
            Trainee trainee = BuscarTrainee(Id);

            if (trainee == null)
            {
                return RedirectToAction("Exibir", "Trainee");
            }

            ViewModelTrainee ViewTrainee = new ViewModelTrainee
            {
                IdTrainee = Id
            };

            ViewTrainee.SetarCampos(trainee, ListaDeTrainees());
            ViewTrainee.Instituicao = trainee.Instituicao;


            return View(ViewTrainee);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Checar(ViewModelTrainee ViewTrainee)
        {
            Trainee trainee = BuscarTrainee(ViewTrainee);

            if (trainee == null)
            {
                return RedirectToAction("Deletar", "Trainee");
            }

            ViewTrainee.SetarCampos(trainee, ListaDeTrainees());
            ViewTrainee.Instituicao = trainee.Instituicao;

            return View(ViewTrainee);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(ViewModelTrainee ViewTrainee)
        {
            Trainee trainee = BuscarTrainee(ViewTrainee);

            if (trainee == null)
            {
                return RedirectToAction("Deletar", "Trainee");
            }

            ctx.Trainees.Remove(trainee);
            ctx.SaveChanges();

            return RedirectToAction("Exibir", "Trainee");
        }

    }
}