using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TALLER.DATA.Contrat;
using TALLER.ENTITY;
using TALLER.ENTITY.Models.Views;

namespace TALLER.DATA.Repository
{
    public class ListReciboRepository : IListReciboRepository
    {

        readonly TalleresContext context;
        public ListReciboRepository(TalleresContext ctx)
        {
            context = ctx;
        }
        public IQueryable<VRecibo> GetAll()
        {
            return context.VRecibo.AsQueryable();
        }
    }
}
