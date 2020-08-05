using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TALLER.BUSINESS.Base;
using TALLER.BUSINESS.Contract;
using TALLER.COMMON.Filter;
using TALLER.DATA.Contrat.Base;
using TALLER.ENTITY.Dto;
using TALLER.ENTITY.Models;

namespace TALLER.BUSINESS.Engines
{
    public class AUTOMOVILEngine : EngineBase<AUTOMOVIL>, IAUTOMOVILEngine
    {
        readonly IMapper mapper;
        public AUTOMOVILEngine(IBaseRepository<AUTOMOVIL> repository, IMapper _mapper): base(repository)
        {
            mapper = _mapper;
        }

        public IEnumerable<AUTOMOVILDto> GetPaged(AUTOMOVILFilter filter)
        {
            var result = base.FindAll();
            if (filter.Tipo != null)
                result = result.Where(c => c.Tipo == filter.Tipo).OrderByDescending(c=> c.Id);
            if (filter.Modelo != null)
                result = result.Where(c => c.Modelo == filter.Modelo).OrderByDescending(c=> c.Id);
            if (filter.MARCA != null)
                result = result.Where(c => c.MARCA == filter.MARCA).OrderByDescending(c=> c.Id);
            var list = mapper.ProjectTo<AUTOMOVILDto>(result);
            return list.OrderByDescending(c=> c.Id);
        }
    }
}
