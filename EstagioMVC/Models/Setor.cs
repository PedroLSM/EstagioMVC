using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstagioMVC.Models
{
    public class Setor
    {
        public int Id { get; set; }

        [Required]
        public string Area { get; set; }
    }
}