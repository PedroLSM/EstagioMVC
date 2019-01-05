using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstagioMVC.Models
{
    [Table("Historico")]
    public class Historico
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }


        [Required]
        public Curso Curso { get; set; }
        public int CursoId { get; set; }

        [Required]
        public Trainee Trainee { get; set; }
        public int TraineeId { get; set; }


        [Required]
        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }
    }
}