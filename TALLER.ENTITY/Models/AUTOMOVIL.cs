using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TALLER.ENTITY.Models
{
    [Table("AUTOMOVIL", Schema = "dbo")]
    public class AUTOMOVIL : BaseEntity
    {
        public string Color { get; set; }
        public string MARCA { get; set; }
        public string Transmision { get; set; }
        public string Lugar_Fabricacion { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
    }
}
