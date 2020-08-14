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
        readonly IBaseRepository<SOLICITUD> solicitud;
        readonly IBaseRepository<MECANICO> mecanico;
        public RECIBOEngine(IBaseRepository<RECIBO> repository,IBaseRepository<SOLICITUD> _solicitud,IBaseRepository<MECANICO> _mecanico, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;
            solicitud = _solicitud;
            mecanico = _mecanico;
        }


        public IEnumerable<RECIBODto> GetPaged(RECIBOFilter filter)
        {
            var result = base.FindAll();
            if (filter.Id != 0)
                result = result.Where(c => c.Id == filter.Id).OrderByDescending(c=> c.Id);

            if (filter.FirstDate != null && filter.EndDate == null)
                throw new ArgumentException("Para buscar se necesita fecha hasta");
            if (filter.FirstDate == null && filter.EndDate != null)
                throw new ArgumentException("Para buscar se necesita fecha desde");
            if (filter.FirstDate != null && filter.EndDate != null)
            {
                if (filter.EndDate > filter.FirstDate)
                {
                    throw new ArgumentException("La fecha hasta no puede ser mayor que la fecha desde");
                }
                else
                {
                    result = result.Where(c => c.CreateDate >= filter.FirstDate && c.CreateDate <= filter.EndDate).OrderByDescending(c => c.Id);
                }
            }

            var list = mapper.ProjectTo<RECIBODto>(result);
            return list.OrderByDescending(c => c.Id);
        }

        private void RestCountMecanic(RECIBO data)
        {
            foreach( var item in solicitud.FindByCondition(s=> s.Id == data.ID_SOLICITUD).ToList())
            {
                var mecanic = item.ID_MECANICO;

                foreach (var mec in mecanico.FindByCondition(m=> m.Id == mecanic).ToList())
                {
                    mec.CountCar = mec.CountCar - 1;
                    mecanico.Update(mec);

                }
            }
        }

        private void ChangeStatus(RECIBO data)
        {
            foreach (var item in solicitud.FindByCondition( s=> s.Id == data.ID_SOLICITUD).ToList())
            {
                item.Status = Char.ToString('E');
                solicitud.Update(item);
            }
        }


        public int InsertRecibo(RECIBO data)
        {
            RestCountMecanic(data);
            ChangeStatus(data);
            return base.Create(data);
        }

    }
}
