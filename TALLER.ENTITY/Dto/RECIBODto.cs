using System;
using System.Collections.Generic;
using System.Text;

namespace TALLER.ENTITY.Dto
{
    public class RECIBODto : BaseDto
    {
        public string Comentario { get; set; }
        public string Nombre_mecanico { get; set; }
        public string Nombre_cliente{ get; set; }
        public string Especialidad { get; set; }
        public string Cedula { get; set; }

        public int ID_SOLICITUD { get; set; }

    }
}
