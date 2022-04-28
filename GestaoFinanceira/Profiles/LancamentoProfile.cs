using AutoMapper;
using GestaoFinanceira.Data.Dtos;
using GestaoFinanceira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFinanceira.Profiles
{
    public class LancamentoProfile : Profile
    {
        public LancamentoProfile()
        {
            CreateMap<CreateLancamentoDto, Lancamento>();
            CreateMap<Lancamento, ReadLancamentoDto>();
            CreateMap<UpdateLancamentoDto, Lancamento>();
        }
    }
}
