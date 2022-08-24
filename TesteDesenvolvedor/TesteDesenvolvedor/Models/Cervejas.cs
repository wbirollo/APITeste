using Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDesenvolvedor.Models
{
    [Table("Cervejas")]
    public class Cervejas
    {
        [Key]
        public int IdCervejas { get; set; }

        [Required(ErrorMessage = "Insira um nome!")]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira um preço!")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Preco { get; set; }


        public Cervejas()
        {
        }

        public Cervejas(int idCervejas, string nome, double preco)
        {
            IdCervejas = idCervejas;
            Nome = nome;
            Preco = preco;
        }

        public List<Cervejas> GetProdutosNome(string nome, List<Cervejas> cervejas)
        {
            return cervejas.Where(c => c.Nome == nome).OrderBy(c => c.Nome).ToList();

        }

        public List<Cervejas> GetBuscaPaginada(RequisicaoBuscaPaginada requisicaoBuscaPaginada, List<Cervejas> lCervejas)
        {
            return lCervejas.Skip((requisicaoBuscaPaginada.PaginaAtual) * requisicaoBuscaPaginada.ItensPagina)
                    .Take(requisicaoBuscaPaginada.ItensPagina)
                    .ToList();
        }
    }
}
