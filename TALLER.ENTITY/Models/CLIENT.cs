using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace TALLER.ENTITY.Models
{
    [Table("CLIENT", Schema = "dbo")]
    public class CLIENT : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public int ID_AUTOMOVIL { get; set; }

        [ForeignKey("ID_AUTOMOVIL")]
        public AUTOMOVIL AUTOMOVIL { get; set; }
        

    }
}
