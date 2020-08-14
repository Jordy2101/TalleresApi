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
    public class MECANICOEngine : EngineBase<MECANICO>, IMECANICOEngine
    {
        readonly IMapper mapper;
        public MECANICOEngine(IBaseRepository<MECANICO> repository, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;
        }

        public IEnumerable<MECANICODto> GetPaged(MECANICOFilter filter)
        {
            var result = base.FindAll();
            if (filter.Nombre != null)
                result = result.Where(c => c.Nombre == filter.Nombre).OrderByDescending(c=> c.Id);
            if (filter.Tipo_Mecanico != null)
                result = result.Where(c => c.Tipo_Mecanico == filter.Tipo_Mecanico).OrderByDescending(c => c.Id);
            if (filter.Especialidad != null)
                result = result.Where(c => c.Especialidad == filter.Especialidad).OrderByDescending(c => c.Id);
            if (filter.Id != 0)
                result = result.Where(c => c.Id == filter.Id).OrderByDescending(c=> c.Id);
           
            var list = mapper.ProjectTo<MECANICODto>(result);
            return list.OrderByDescending(c => c.Id);
        }
        public int InsertMecanico(MECANICO data)
        {
            return base.Create(data);
        }

    }
}
