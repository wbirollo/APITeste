using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDesenvolvedor.Models;

namespace Backend.Models
{
    public class ResultadoBuscaVendas
    {
        public ResultadoBuscaPaginada paginada { get; set; }

        public List<Vendas> Itens { get; set; }
    }
}
