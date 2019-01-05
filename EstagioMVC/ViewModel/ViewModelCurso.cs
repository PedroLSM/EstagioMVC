using EstagioMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstagioMVC.ViewModel
{
    public class ViewModelCurso
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        [Display(Name = "Carga Horária")]
        public int Carga { get; set; }

        public int IdCurso { get; set; }

        [Required]
        public int Curso;
        public IEnumerable<Curso> Cursos;

        [Required]
        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }
        public int[] Notas { get; } = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public void SetarCampos(Curso curso, List<Curso> ListaDeCurso)
        {
            Nome = curso.Nome;
            Autor = curso.Autor;
            Carga = curso.CargaHoraria;
            Avaliacao = curso.Classificacao;
            Cursos = ListaDeCurso;
        }
    }
}