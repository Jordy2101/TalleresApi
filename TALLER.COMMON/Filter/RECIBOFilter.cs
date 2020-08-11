using System;
using System.Collections.Generic;
using System.Text;

namespace TALLER.COMMON.Filter
{
  public  class RECIBOFilter : BaseFilter
    {
        public int Id { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime? EndDate { get; set; }
  
    }
}
