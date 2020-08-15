using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        readonly IBaseRepository<MECANICO> mecanico;
        readonly IBaseRepository<CLIENT> cliente;
        readonly IBaseRepository<AUTOMOVIL> automovil;

        public SOLICITUDEngine(IBaseRepository<SOLICITUD> repository, IBaseRepository<MECANICO> _mecanico, IBaseRepository<CLIENT> _cliente, IBaseRepository<AUTOMOVIL> _automovil, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;
            mecanico = _mecanico;
            cliente = _cliente;
            automovil = _automovil;
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

            var list = mapper.ProjectTo<SOLICITUDDto>(result);
            return list.OrderByDescending(c => c.Id);
        }


        private void MecanicoCount(SOLICITUD data)
        {
            foreach ( var item in mecanico.FindByCondition(c=> c.Id == data.ID_MECANICO).ToList())
            {
                if(item.CountCar == 3)
                {
                    throw new ArgumentException("El mecanico tiene el limite de " + item.CountCar +" Autos aceptados");
                }
                else
                {
                    item.CountCar = item.CountCar +1;
                    mecanico.Update(item);
                }
            }   
        }

        private void MecanicoSpecial(SOLICITUD data)
        {
            foreach (var item in mecanico.FindByCondition(m => m.Id == data.ID_MECANICO).ToList())
            {
                var specialmecanico = item.Especialidad;

                foreach (var ite in cliente.FindByCondition(c => c.Id == data.ID_CLIENTE).ToList())
                {
                    foreach (var car in automovil.FindByCondition(a => a.Id == ite.ID_AUTOMOVIL).ToList())
                    {
                        if (car.MARCA != specialmecanico)
                        {
                            throw new ArgumentException("El mecanico no esta especializado para este auto");
                        }
                        else {

                            MecanicoCount(data);

                        }
                        
                    }
                }
            }
        }

        public int InsertSolicitud(SOLICITUD data)
        {
           
            MecanicoSpecial(data);
            return base.Create(data);
        }
    }
}
