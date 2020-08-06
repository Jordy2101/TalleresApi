using System;
using System.Collections.Generic;
using System.Text;

namespace TALLER.ENTITY.Dto
{
   public class CLIENTDto : BaseDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Modelo { get; set; }
        public int ID_AUTOMOVIL { get; set; }
    }
}
