using System;
using System.Collections.Generic;
using System.Text;

namespace TALLER.ENTITY.Dto.ViewsDto
{
    public class ListSolicitud :BaseDto
    {
        public int ID_CLIENTE { get; set; }
        public string Nombre_Completo_Cliente { get; set; }
        public string Cedula { get; set; }
        public int ID_MECANICO { get; set; }
        public string Nombre_Completo_Mecanico { get; set; }
        public string Tipo_Mecanico { get; set; }
        public string Especialidad { get; set; }
        public int CountCar { get; set; }
        public DateTime Date { get; set; }
        public string Descripcion { get; set; }
    }
}
