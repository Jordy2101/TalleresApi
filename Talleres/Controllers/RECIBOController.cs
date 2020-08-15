using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocumentFormat.OpenXml.Drawing;
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
    [Route("api/[controller]")]
    [ApiController]
    public class RECIBOController : BaseApiController<RECIBO, RECIBODto, IEngineBase<RECIBO>>
    {

        readonly IRECIBOEngine detail;

    public RECIBOController(IEngineBase<RECIBO> manager, IRECIBOEngine _detail, IMapper mapper) : base(manager, mapper)
    {
        detail = _detail;
    }


        [AllowAnonymous]
        [Route("PostRecibo/{comentario}/{id_solicitud}")]
        [HttpGet, DisableRequestSizeLimit]
        public ActionResult PostRecibo(string comentario,int id_solicitud)
        {
            try
            {
                var data = new RECIBO()
                {
                    Comentario = comentario,
                    ID_SOLICITUD = id_solicitud

                };
                detail.InsertRecibo(data);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }






        [HttpGet]
      [Route("GetPaged")]
    public ActionResult GetPagedList([FromQuery] RECIBOFilter filter)
    {
        try
        {
            var empty = new List<RECIBO>();
            var data = detail.GetPaged(filter);
            var result = PagedList<RECIBODto>.Create(data.AsQueryable(), filter.PageNumber, filter.PageSize);
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
