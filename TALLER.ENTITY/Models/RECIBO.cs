using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TALLER.ENTITY.Models
{
    [Table("RECIBO", Schema = "dbo")]
    public class RECIBO :BaseEntity
    {
        public string Comentario { get; set; }
        public int ID_SOLICITUD { get; set; }

        [ForeignKey("ID_SOLICITUD")]
        public SOLICITUD SOLICITUD { get; set; }
    }
}
