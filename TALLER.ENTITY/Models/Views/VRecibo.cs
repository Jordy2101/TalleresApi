using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TALLER.ENTITY.Models.Views
{
    [Table("VRecibo", Schema = "dbo")]
    public class VRecibo : BaseEntity
    {
        public int ID_SOLICITUD { get; set; }
        public int ID_CLIENTE { get; set; }
        public string Nombre_Completo_Cliente { get; set; }
        public string Cedula { get; set; }
        public int ID_MECANICO { get; set; }
        public string Nombre_Completo_Mecanico { get; set; }
        public string Especialidad { get; set; }
        public DateTime Date { get; set; }
        public string Comentario { get; set; }
    }
}
