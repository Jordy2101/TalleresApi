using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
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
    public class AUTOMOVILController : BaseApiController<AUTOMOVIL, AUTOMOVILDto, IEngineBase<AUTOMOVIL>>
    {
        readonly IAUTOMOVILEngine detail;

        public AUTOMOVILController(IEngineBase<AUTOMOVIL> manager, IAUTOMOVILEngine _detail, IMapper mapper) : base(manager, mapper)
        {
            detail = _detail;
        }



        [HttpGet]
        [Route ("GetPaged")]
        public ActionResult GetPagedList([FromQuery] AUTOMOVILFilter filter)
        {
            try
            {
                var empty = new List<AUTOMOVIL>();
                var data = detail.GetPaged(filter);
                var result = PagedList<AUTOMOVILDto>.Create(data.AsQueryable(), filter.PageNumber, filter.PageSize);
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
