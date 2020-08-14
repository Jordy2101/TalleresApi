using System;
using System.Collections.Generic;
using System.Text;
using TALLER.COMMON.Filter;
using TALLER.ENTITY.Dto;
using TALLER.ENTITY.Models;

namespace TALLER.BUSINESS.Contract
{
   public interface IMECANICOEngine
    {
        IEnumerable<MECANICODto> GetPaged(MECANICOFilter filter);

        int InsertMecanico(MECANICO data);
    }

}
