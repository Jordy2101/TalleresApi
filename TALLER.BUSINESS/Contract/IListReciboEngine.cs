﻿using System;
using System.Collections.Generic;
using System.Text;
using TALLER.COMMON.Filter;
using TALLER.ENTITY.Dto.ViewsDto;
using TALLER.ENTITY.Models.Views;

namespace TALLER.BUSINESS.Contract
{
    public interface IListReciboEngine
    {
        IEnumerable<ListRecibo> GetPaged(ListVReciboFilter filter);
    }
}
