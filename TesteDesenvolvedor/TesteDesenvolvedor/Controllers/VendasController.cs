using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Data;
using TesteDesenvolvedor.Models;

namespace TesteDesenvolvedor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly TesteDesenvolvedorContext _context;

        public VendasController(TesteDesenvolvedorContext context)
        {
            _context = context;
        }

        // GET: api/Vendas
        [HttpPost("BuscarVendas")]
        public async Task<ActionResult<ResultadoBuscaVendas>> GetVendas([FromBody] RequisicaoBuscaVendas requisicao)
        {

            List<Vendas> lVendas = new List<Vendas>(await _context.Vendas.ToListAsync());

            if (lVendas.Count == 0)
            {
                return NotFound();
            }

            lVendas = lVendas[0].ProcuraPorData(requisicao.DataMin, requisicao.DataMax, lVendas);


            List<Vendas> lPaginaVendas = lVendas[0].GetBuscaPaginada(requisicao.paginacao, lVendas);

            ResultadoBuscaPaginada resultPagina = new ResultadoBuscaPaginada();
            resultPagina.PaginaAtual = requisicao.paginacao.PaginaAtual;
            resultPagina.TotalItens = lVendas.Count;
            resultPagina.TotalPaginas = lVendas.Count / requisicao.paginacao.ItensPagina;

            ResultadoBuscaVendas buscaVendas = new ResultadoBuscaVendas();
            buscaVendas.Itens = lPaginaVendas;
            buscaVendas.paginada = resultPagina;

            return buscaVendas;

        }

        // GET: api/Vendas/id
        [HttpGet("ObterVenda/{id}")]

        public async Task<ActionResult<Vendas>> GetVendas(int id)
        {
            var vendas = await _context.Vendas.FindAsync(id);

            if (vendas == null)
            {
                return NotFound();
            }

            return vendas;
        }


        // POST: api/Vendas
        [HttpPost("AdicionarVenda")]
        public async Task<ActionResult<Vendas>> PostVendas(Vendas venda)
        {
            List<Cervejas> lCervejas = new List<Cervejas>(await _context.Cervejas.ToListAsync());
            venda = venda.AdicionarVenda(venda, lCervejas);            

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            return venda;
        }


        private bool VendasExists(int id)
        {
            return _context.Vendas.Any(e => e.IdVendas == id);
        }
    }
}
