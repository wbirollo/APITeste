using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDesenvolvedor.Models
{
    [Table("ItensVenda")]
    public class ItensVenda
    {
        [Key]
        public int IdItem { get; set; }
        public int QuantidadeItem { get; set; }

        public Cervejas Cerveja { get; set; }
        
        [Required(ErrorMessage = "Insira um Id!")]
        public int CervejasId { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TotalItem { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double CashbackItem { get; set; }

        public ItensVenda()
        {
        }

        public ItensVenda(int idItem, int quantidadeItem, double totalItem)
        {
            IdItem = idItem;
            QuantidadeItem = quantidadeItem;
            TotalItem = totalItem;
        }

        public ItensVenda AdicionarItemVenda(Vendas venda, ItensVenda item)
        {
            item.TotalItem = 0;
            if (item.Cerveja.Nome == "Skol")
            {
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)0)
                {
                    item.CashbackItem = 0.25 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)1)
                {
                    item.CashbackItem = 0.07 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)2)
                {
                    item.CashbackItem = 0.06 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)3)
                {
                    item.CashbackItem = 0.02 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)4)
                {
                    item.CashbackItem = 0.1 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)5)
                {
                    item.CashbackItem = 0.15 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)6)
                {
                    item.CashbackItem = 0.2 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
            }

            else if (item.Cerveja.Nome == "Brahma")
            {
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)0)
                {
                    item.CashbackItem = 0.3 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)1)
                {
                    item.CashbackItem = 0.05 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)2)
                {
                    item.CashbackItem = 0.1 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)3)
                {
                    item.CashbackItem = 0.15 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)4)
                {
                    item.CashbackItem = 0.2 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)5)
                {
                    item.CashbackItem = 0.25 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)6)
                {
                    item.CashbackItem = 0.3 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
            }


            else if (item.Cerveja.Nome == "Stella")
            {
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)0)
                {
                    item.CashbackItem = 0.35 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)1)
                {
                    item.CashbackItem = 0.03 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)2)
                {
                    item.CashbackItem = 0.05 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)3)
                {
                    item.CashbackItem = 0.08 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)4)
                {
                    item.CashbackItem = 0.13 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)5)
                {
                    item.CashbackItem = 0.18 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)6)
                {
                    item.CashbackItem = 0.25 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
            }

            else if (item.Cerveja.Nome == "Bohemia")
            {
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)0)
                {
                    item.CashbackItem = 0.40 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)1)
                {
                    item.CashbackItem = 0.1 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)2)
                {
                    item.CashbackItem = 0.15 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)3)
                {
                    item.CashbackItem = 0.15 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)4)
                {
                    item.CashbackItem = 0.15 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)5)
                {
                    item.CashbackItem = 0.2 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
                if (venda.DataVenda.DayOfWeek == (DayOfWeek)6)
                {
                    item.CashbackItem = 0.4 * item.Cerveja.Preco;
                    item.TotalItem += item.QuantidadeItem * (item.Cerveja.Preco - item.CashbackItem);
                }
            }

            return item;
        }
    }
}
