using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using TALLER.BUSINESS.Base;
using TALLER.BUSINESS.Contract;
using TALLER.COMMON.Filter;
using TALLER.DATA.Contrat.Base;
using TALLER.ENTITY.Dto;
using TALLER.ENTITY.Models;

namespace TALLER.BUSINESS.Engines
{
    public class RECIBOEngine : EngineBase<RECIBO>, IRECIBOEngine
    {
        readonly IMapper mapper;
        public RECIBOEngine(IBaseRepository<RECIBO> repository, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;
        }


        public IEnumerable<RECIBODto> GetPaged(RECIBOFilter filter)
        {
            var result = base.FindAll();
            if (filter.Id != 0)
                result = result.Where(c => c.Id == filter.Id).OrderByDescending(c=> c.Id);
            if (filter.Id_solicitud != 0)
                result = result.Where(c => c.ID_SOLICITUD == filter.Id_solicitud).OrderByDescending(c => c.Id);
            if (filter.CreatedDate != null)
                result = result.Where(c => c.CreateDate == filter.CreatedDate).OrderByDescending(c => c.Id);
           
            var list = mapper.ProjectTo<RECIBODto>(result);
            return list.OrderByDescending(c => c.Id);
        }
    }
}
