using BANKFILES.DATA.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TALLER.ENTITY;
using TALLER.ENTITY.Models;

namespace TALLER.DATA.Repository
{
    public class CLIENTRepository : BaseRepository<CLIENT>
    {
        public CLIENTRepository(TalleresContext ctx) : base(ctx)
        {

        }

        public override IQueryable<CLIENT> FindAll()
        {
            return base.FindAll().Where(c => c.Status == "D").Include(c=> c.AUTOMOVIL);
        }
    }
}
