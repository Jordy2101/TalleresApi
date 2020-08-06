using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace TALLER.ENTITY.Models
{

    [Table("SOLICITUD", Schema ="dbo")]
    public class SOLICITUD : BaseEntity
    {
        public string Descripcion { get; set; }
        public int ID_MECANICO { get; set; }
        public int ID_CLIENTE { get; set; }
        [ForeignKey("ID_MECANICO")]
        public MECANICO MECANICO { get; set; }
        [ForeignKey("ID_CLIENTE")]
        public CLIENT CLIENT { get; set; }
    }
}
