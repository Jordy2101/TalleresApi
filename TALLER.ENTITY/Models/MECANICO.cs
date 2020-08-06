using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TALLER.ENTITY.Models
{
    [Table("MECANICO", Schema = "dbo")]
    public class MECANICO : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Tipo_Mecanico { get; set; }
        public string Especialidad { get; set; }
        public int CountCar { get; set; }
    }
}
