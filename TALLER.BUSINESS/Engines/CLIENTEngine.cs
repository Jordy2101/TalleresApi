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
    public class CLIENTEngine : EngineBase<CLIENT>, ICLIENTEngine
    {
        readonly IMapper mapper;
        public CLIENTEngine(IBaseRepository<CLIENT> repository, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;
        }

        public override int Create(CLIENT data)
        {
            return base.Create(data);
        }
        public IEnumerable<CLIENT> GetPaged(CLIENTFilter filter)
        {
            var result = base.FindAll();
            if (filter.Nombre != null)
                result = result.Where(c => c.Nombre == filter.Nombre).OrderByDescending(c => c.Id);
            if (filter.Apellido != null)
                result = result.Where(c => c.Apellido == filter.Apellido).OrderByDescending(c => c.Id);
            if (filter.Cedula != null)
                result = result.Where(c => c.Cedula == filter.Cedula).OrderByDescending(c => c.Id);
            //var list = mapper.ProjectTo<CLIENT>(result);
            //return list.OrderByDescending(c => c.Id);

            return result.OrderByDescending(c => c.Id);
        }

        public int InsertClient(CLIENT data)
        {
            return base.Create(data);
        }
    }
}
