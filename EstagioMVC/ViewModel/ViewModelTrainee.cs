using EstagioMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstagioMVC.ViewModel
{
    public class ViewModelTrainee
    {
        public int IdTrainee { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "Instituição")]
        public string Instituicao { get; set; }

        [Required]
        public int Trainee;
        public IEnumerable<Trainee> Trainees;

        public void SetarCampos(Trainee trainee, List<Trainee> ListaDeTrainees)
        {
            Nome = trainee.Nome;
            Instituicao = trainee.Instituicao;
            Trainees = ListaDeTrainees;
        }
    }
}