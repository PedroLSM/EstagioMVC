using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstagioMVC.Models
{
    [Table("Trainee")]
    public class Trainee
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Instituicao { get; set; }

    }
}