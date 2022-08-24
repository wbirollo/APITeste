using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RequisicaoBuscaPaginada
    {
        public int PaginaAtual { get; set; }

        [Range(1, 100, ErrorMessage = "Valor de itens deve ser entre 1 e 100!")]
        public int ItensPagina { get; set; } 

        
    }
}
