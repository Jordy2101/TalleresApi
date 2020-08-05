using BANKFILES.DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using TALLER.ENTITY;
using TALLER.ENTITY.Models;

namespace TALLER.DATA.Repository
{
    public class AUTOMOVILRepository : BaseRepository<AUTOMOVIL>
    {

        public AUTOMOVILRepository(TalleresContext ctx): base(ctx)
        {

        }
    }
}
