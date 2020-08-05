using System;
using System.Collections.Generic;
using System.Text;

namespace TALLER.ENTITY.Dto
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Status { get; set; }
    }
}
