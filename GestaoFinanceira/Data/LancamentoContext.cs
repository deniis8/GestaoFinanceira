using GestaoFinanceira.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFinanceira.Data
{
    public class LancamentoContext : DbContext
    {
        public LancamentoContext(DbContextOptions<LancamentoContext> opt) : base(opt)
        {

        }
        public DbSet <Lancamento> Lancamentos { get; set; }
    }
}
