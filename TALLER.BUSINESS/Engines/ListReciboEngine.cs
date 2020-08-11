using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TALLER.BUSINESS.Contract;
using TALLER.COMMON.Filter;
using TALLER.DATA.Contrat;
using TALLER.ENTITY.Dto;
using TALLER.ENTITY.Dto.ViewsDto;
using TALLER.ENTITY.Models;
using TALLER.ENTITY.Models.Views;

namespace TALLER.BUSINESS.Engines
{
    public class ListReciboEngine : IListReciboEngine
    {

        readonly IListReciboRepository file;
        public ListReciboEngine(IListReciboRepository _file)
        {
            file = _file;
        }

        public IEnumerable<VRecibo> GetPaged(ListVReciboFilter filter)
        {
            var result = file.GetAll();
            if (filter.Id != 0)
                result = result.Where(c => c.Id == filter.Id);
            if (filter.Nombre_Completo_Cliente != null)
                result = result.Where(c=> c.Nombre_Completo_Cliente == filter.Nombre_Completo_Cliente);
            if (filter.Cedula != null)
                result = result.Where(c=> c.Cedula == filter.Cedula);
            if (filter.FirstDate == null && filter.EndDate != null)
                throw new ArgumentException("Se necesita la fecha de inicio para la busqueda");
            if (filter.FirstDate != null & filter.EndDate == null)
                throw new ArgumentException("Se necesita la fecha final para la busqueda");
            if (filter.FirstDate != null && filter.EndDate != null )
            {
                if (filter.EndDate < filter.FirstDate)
                    throw new ArgumentException("La fecha desde no puede ser mayor que hasta");
                result = result.Where(c => c.Date >= filter.FirstDate && c.Date <= filter.EndDate);
                if (result.Count() == 0)
                    throw new ArgumentException("No existen datos con los parametros suministrado por el usuario");
            }


            return result.OrderByDescending(c => c.Date);
        }
    }
}
