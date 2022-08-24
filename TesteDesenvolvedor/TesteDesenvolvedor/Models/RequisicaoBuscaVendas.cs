using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RequisicaoBuscaVendas
    {
        public RequisicaoBuscaPaginada paginacao {get; set;}

        [DataType(DataType.Date)]
        public DateTime DataMin { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataMax { get; set; }
    }
        
}