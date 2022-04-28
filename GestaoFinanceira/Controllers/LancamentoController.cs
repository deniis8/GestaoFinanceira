using AutoMapper;
using GestaoFinanceira.Data;
using GestaoFinanceira.Data.Dtos;
using GestaoFinanceira.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFinanceira.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoController : ControllerBase
    {
        private LancamentoContext _context;
        private IMapper _mapper;


        public LancamentoController(LancamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        //[FromBody] O Lançamento vem do corpo da requisição
        public IActionResult AdicionaLancamento([FromBody] CreateLancamentoDto lancamentoDto)
        {
            Lancamento lancamento = _mapper.Map<Lancamento>(lancamentoDto);
            _context.Lancamentos.Add(lancamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaLancamentoPorId), new { Id = lancamento.Id }, lancamento);
        }

        [HttpGet]
        public IEnumerable<Lancamento> RecuperarLancamento() {
            return _context.Lancamentos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarLancamentoPorId(int id)
        {
            Lancamento lancamento = _context.Lancamentos.FirstOrDefault(filmes => filmes.Id == id);
            if (lancamento != null)
            {
                ReadLancamentoDto lancamentoDto = _mapper.Map<ReadLancamentoDto>(lancamento);
                return Ok(lancamentoDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult RecuperaLancamentoPorId(int id, [FromBody] UpdateLancamentoDto lancamentoDto)
        {
            Lancamento lancamento = _context.Lancamentos.FirstOrDefault(lancamento => lancamento.Id == id);
            if (lancamento == null)
            {
                return NotFound();
            }

            _mapper.Map(lancamentoDto, lancamento);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaLancamento(int id)
        {
            Lancamento lancamento = _context.Lancamentos.FirstOrDefault(lancamento => lancamento.Id == id);
            if (lancamento == null)
            {
                return NotFound();
            }

            _context.Remove(lancamento);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
