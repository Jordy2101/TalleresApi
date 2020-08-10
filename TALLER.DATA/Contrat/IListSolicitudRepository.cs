using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TALLER.ENTITY.Models.Views;

namespace TALLER.DATA.Contrat
{
    public interface IListSolicitudRepository
    {
        IQueryable<VSolicitud> GetAll();
    }
}
