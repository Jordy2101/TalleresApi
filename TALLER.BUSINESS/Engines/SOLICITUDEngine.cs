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
    public class SOLICITUDEngine : EngineBase<SOLICITUD>, ISOLICITUDEngine
    {
        readonly IMapper mapper;
        public SOLICITUDEngine(IBaseRepository<SOLICITUD> repository, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;
        }


        public IEnumerable<SOLICITUDDto> GetPaged(SOLICITUDFilter filter)
        {
            var result = base.FindAll();
          
            if (filter.Id != 0)
                result = result.Where(c => c.Id == filter.Id).OrderByDescending(c => c.Id);
            if (filter.Id_cliente != 0)
                result = result.Where(c => c.ID_CLIENTE == filter.Id_cliente).OrderByDescending(c => c.Id);
            if (filter.Id_mecanico != 0)
                result = result.Where(c => c.ID_MECANICO == filter.Id_mecanico).OrderByDescending(c => c.Id);
            if (filter.CreatedDate != null)
                result = result.Where(c => c.CreateDate == filter.CreatedDate).OrderByDescending(c => c.Id);
          
            var list = mapper.ProjectTo<SOLICITUDDto>(result);
            return list.OrderByDescending(c => c.Id);
        }
    }
}
