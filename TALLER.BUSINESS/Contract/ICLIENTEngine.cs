using System;
using System.Collections.Generic;
using System.Text;
using TALLER.ENTITY.Models;
using TALLER.ENTITY.Dto;
using TALLER.COMMON.Filter;

namespace TALLER.BUSINESS.Contract
{
   public interface ICLIENTEngine
    {
        IEnumerable<CLIENTDto> GetPaged(CLIENTFilter filter);
        int InsertClient(CLIENT data);
    }
}
