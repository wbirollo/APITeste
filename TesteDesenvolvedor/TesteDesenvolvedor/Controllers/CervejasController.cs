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
    public class CervejasController : ControllerBase
    {
        private readonly TesteDesenvolvedorContext _context;

        public CervejasController(TesteDesenvolvedorContext context)
        {
            _context = context;
        }

        // GET: api/Cervejas
        [HttpPost("BuscarCervejas")]
        public async Task<ActionResult<ResultadoBuscaCervejas>> GetCervejas([FromBody]RequisicaoBuscaCervejas requisicao)
        {
            List<Cervejas> lCervejas = new List<Cervejas>(await _context.Cervejas.ToListAsync());

            if (lCervejas.Count == 0)
            {
                return NotFound();
            }
            if (requisicao.NomeFiltro != "string" && requisicao.NomeFiltro != "")
            {
                lCervejas = lCervejas[0].GetProdutosNome(lCervejas[0].Nome, lCervejas);
            }

            List<Cervejas> lPaginaCervejas = lCervejas[0].GetBuscaPaginada(requisicao.paginacao, lCervejas);

            ResultadoBuscaPaginada resultPagina = new ResultadoBuscaPaginada();
            resultPagina.PaginaAtual = requisicao.paginacao.PaginaAtual;
            resultPagina.TotalItens = lCervejas.Count;
            resultPagina.TotalPaginas = lCervejas.Count/ requisicao.paginacao.ItensPagina;

            ResultadoBuscaCervejas buscaCervejas = new ResultadoBuscaCervejas();
            buscaCervejas.Itens = lPaginaCervejas;
            buscaCervejas.paginada = resultPagina;

            return buscaCervejas;
        }

        // GET: api/Cervejas/id
        [HttpGet("ObterCerveja/{id}")]
        public async Task<ActionResult<Cervejas>> GetCervejas(int id)
        {
            var cerveja = await _context.Cervejas.FindAsync(id);

            if (cerveja == null)
            {
                return NotFound();
            }

            return cerveja;
        }

    }        
}
