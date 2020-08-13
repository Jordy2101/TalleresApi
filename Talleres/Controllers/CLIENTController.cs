using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TALLER.BUSINESS.Base.Contract;
using TALLER.BUSINESS.Contract;
using TALLER.COMMON.Filter;
using TALLER.COMMON.Paged;
using TALLER.ENTITY.Dto;
using TALLER.ENTITY.Models;
using Talleres.Infraestructure.Base;

namespace Talleres.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CLIENTController : BaseApiController<CLIENT, CLIENTDto, IEngineBase<CLIENT>>
    {

        readonly ICLIENTEngine detail;

        public CLIENTController(IEngineBase<CLIENT> manager, ICLIENTEngine _detail, IMapper mapper) : base(manager, mapper)
        {
            detail = _detail;
        }


        [HttpGet, DisableRequestSizeLimit]
        [AllowAnonymous]
        [Route("PostClient/{nombre}/{apellido}/{direccion}/{cedula}/{iD_AUTOMOVIL}")]
        public ActionResult PostClient(string nombre, string apellido, string direccion, string cedula, int iD_AUTOMOVIL)
        {
            try
            {

                var data = new CLIENT()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Direccion = direccion,
                    Cedula = cedula,
                    ID_AUTOMOVIL = iD_AUTOMOVIL

                };
                detail.InsertClient(data);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("GetPaged")]
        public ActionResult GetPagedList([FromQuery] CLIENTFilter filter)
        {
            try
            {
                var empty = new List<CLIENT>();
                var data = detail.GetPaged(filter);
                var result = PagedList<CLIENT>.Create(data.AsQueryable(), filter.PageNumber, filter.PageSize);
                if (result == null)
                {
                    return BadRequest("No existen datos con este filtro");
                }
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
