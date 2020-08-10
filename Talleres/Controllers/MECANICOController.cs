﻿using System;
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
using TALLER.ENTITY.Dto;
using TALLER.ENTITY.Models;
using Talleres.Infraestructure.Base;

namespace Talleres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MECANICOController : BaseApiController<MECANICO, MECANICODto, IEngineBase<MECANICO>>
    {
        readonly IMECANICOEngine detail;

        public MECANICOController(IEngineBase<MECANICO> manager, IMECANICOEngine _detail, IMapper mapper) : base(manager, mapper)
        {
            detail = _detail;
        }



        [HttpGet]
        [Route("GetPaged")]
        public ActionResult GetPagedList([FromQuery] MECANICOFilter filter)
        {
            try
            {
                var empty = new List<MECANICO>();
                var data = detail.GetPaged(filter);
                var result = PagedList<MECANICODto>.Create(data.AsQueryable(), filter.PageNumber, filter.PageSize);
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