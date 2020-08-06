using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using TALLER.ENTITY.Models;

namespace TALLER.COMMON.Filter
{
   public class SOLICITUDFilter : BaseFilter
    {
      
       public int Id { get; set;}
        public int Id_mecanico { get; set; }
        public int Id_cliente { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
