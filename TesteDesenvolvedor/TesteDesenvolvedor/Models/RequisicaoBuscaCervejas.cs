using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RequisicaoBuscaCervejas
    {
        public RequisicaoBuscaPaginada paginacao {get; set;}

        public string NomeFiltro { get; set; }
    }
        
}