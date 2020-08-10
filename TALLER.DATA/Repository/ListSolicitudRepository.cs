using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TALLER.DATA.Contrat;
using TALLER.ENTITY;
using TALLER.ENTITY.Models.Views;

namespace TALLER.DATA.Repository
{
    public class ListSolicitudRepository : IListSolicitudRepository
    {

        readonly TalleresContext context;

        public ListSolicitudRepository(TalleresContext ctx)
        {
            context = ctx;
        }
        public IQueryable<VSolicitud> GetAll()
        {
            return context.VSolicitud.AsQueryable();
        }
    }
}
