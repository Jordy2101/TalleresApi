using System;
using System.Collections.Generic;
using System.Text;
using TALLER.COMMON.Filter;
using TALLER.ENTITY.Dto;

namespace TALLER.BUSINESS.Contract
{
   public interface ISOLICITUDEngine
    {


        IEnumerable<SOLICITUDDto> GetPaged(SOLICITUDFilter filter);
    }
}
