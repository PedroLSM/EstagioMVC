using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstagioMVC.Models
{
    [Table("Curso")]
    public class Curso
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public int CargaHoraria { get; set; }

        public int Classificacao { get; set; }
    }
}