using System;
using System.Collections.Generic;
using System.Text;

namespace TALLER.ENTITY.Dto
{
    public class MECANICODto : BaseDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Tipo_Mecanico { get; set; }
        public string Especialidad { get; set; }
        public int CountCar { get; set; }
    }
}
