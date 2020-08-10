using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TALLER.BUSINESS.Base.Contract;
using TALLER.BUSINESS.Contract;
using TALLER.COMMON.Filter;
using TALLER.COMMON.Paged;
using TALLER.ENTITY.Dto.ViewsDto;
using TALLER.ENTITY.Models.Views;
using Talleres.Infraestructure.Base;

namespace Talleres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListSolicitudController : Controller
    {
        readonly IListSolicitudEngine service;
        public ListSolicitudController(IListSolicitudEngine _service)
        {
            service = _service;
        }
        [HttpGet]
        public ActionResult GetPaged([FromQuery] ListSolicitudFilter filter)
        {
            try
            {
                var data = service.GetPaged(filter);
                var result = PagedList<VSolicitud>.Create((IQueryable<VSolicitud>)data.AsQueryable(), filter.PageNumber, filter.PageSize);
                if (result == null) { return BadRequest("No existen registros con los parametros de busqueda"); }
                var pagination = new
                {
                    totalCount = result.TotalCount,
                    pageSize = result.PageSize,
                    currentPage = result.CurrentPage,
                    totalPage = result.TotalPages,
                    HasNext = result.HasNext,
                    HasPrevious = result.HasPrevious,
                    data = result
                };
                return Ok(pagination);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }
    }
}
