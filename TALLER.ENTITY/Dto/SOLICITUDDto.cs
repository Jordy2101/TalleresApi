using System;
using System.Collections.Generic;
using System.Text;

namespace TALLER.ENTITY.Dto
{
    public class SOLICITUDDto : BaseDto
    {
        public string Descripcion { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Nombre_Mecanico { get; set; }
        public string Especialidad { get; set; }
        public string Cedula { get; set; }
        public int ID_MECANICO { get; set; }
        public int ID_CLIENTE { get; set; }
    }
}
