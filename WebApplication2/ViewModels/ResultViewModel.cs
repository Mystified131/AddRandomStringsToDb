using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class ResultViewModel
    {
        [Required]
        public int leng { get; set; }
        [Required]
        public int quant { get; set; }
        public List<string> RandomKeys { get; set; }
        public List<Listelement> TheList { get; set; }
    }
}
