using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Models;

namespace TesteDesenvolvedor.Data
{
    public class TesteDesenvolvedorContext : DbContext
    {
        public TesteDesenvolvedorContext (DbContextOptions<TesteDesenvolvedorContext> options)
            : base(options)
        {
        }

        public DbSet<TesteDesenvolvedor.Models.Cervejas> Cervejas { get; set; }

        public DbSet<TesteDesenvolvedor.Models.Vendas> Vendas { get; set; }

        public DbSet<TesteDesenvolvedor.Models.ItensVenda> ItensVendas { get; set; }
    }
}
