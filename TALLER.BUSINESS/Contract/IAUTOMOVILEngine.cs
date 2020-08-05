using System;
using System.Collections.Generic;
using System.Text;
using TALLER.COMMON.Filter;
using TALLER.ENTITY.Dto;
using TALLER.ENTITY.Models;

namespace TALLER.BUSINESS.Contract
{
    public interface IAUTOMOVILEngine
    {

        IEnumerable<AUTOMOVILDto> GetPaged(AUTOMOVILFilter filter);
    }
}
