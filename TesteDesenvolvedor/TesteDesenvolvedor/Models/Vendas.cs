using Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDesenvolvedor.Models
{
    [Table("Vendas")]
    public class Vendas
    {
        [Key]
        public int IdVendas { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataVenda { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TotalVenda { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double CashbackTotal { get; set; }

        public List<ItensVenda> ItensVenda { get; set; } = new List<ItensVenda>();


        public Vendas()
        {
        }

        public Vendas(int idVendas, int quantidadeItens, DateTime dataVenda, double totalVenda)
        {
            IdVendas = idVendas;
            DataVenda = dataVenda;
            TotalVenda = totalVenda;

        }
        public List<Vendas> GetBuscaPaginada(RequisicaoBuscaPaginada requisicaoBuscaPaginada, List<Vendas> lVendas)
        {
            return lVendas.Skip((requisicaoBuscaPaginada.PaginaAtual) * requisicaoBuscaPaginada.ItensPagina)
                    .Take(requisicaoBuscaPaginada.ItensPagina)
                    .ToList();
        }

        public List<Vendas> ProcuraPorData(DateTime? minData, DateTime? maxData, List<Vendas> lVendas)
        {
            if (minData.HasValue)
            {
                lVendas.Where(x => x.DataVenda >= minData.Value);

            }
            if (maxData.HasValue)
            {
                lVendas.Where(x => x.DataVenda >= maxData.Value);
            }

            return lVendas.OrderBy(x => x.DataVenda).ToList();
        }       

        public Vendas AdicionarVenda(Vendas venda, List<Cervejas> lCervejas)
        {
            venda.TotalVenda = 0;
            List<ItensVenda> itensVenda = venda.ItensVenda.ToList();
            foreach (ItensVenda item in itensVenda)
            {
                foreach (Cervejas cerveja in lCervejas)
                {
                    if (item.CervejasId == cerveja.IdCervejas)
                    {
                        item.Cerveja = cerveja;                        
                    }                  
                }
                ItensVenda itemVenda = item.AdicionarItemVenda(venda, item);
                item.CashbackItem = itemVenda.CashbackItem * item.QuantidadeItem;

                venda.CashbackTotal += item.CashbackItem;
                venda.TotalVenda += itemVenda.TotalItem;
            }
            venda.ItensVenda = itensVenda;

            return venda;
        }

    }

}


