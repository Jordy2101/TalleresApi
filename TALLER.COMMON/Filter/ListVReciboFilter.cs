using System;
using System.Collections.Generic;
using System.Text;

namespace TALLER.COMMON.Filter
{
    public class ListVReciboFilter : BaseFilter
    {
        public int Id { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Nombre_Completo_Cliente { get; set; }
        public string Cedula { get; set; }
    }
}
