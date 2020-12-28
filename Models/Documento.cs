using System;
using System.Collections;
using System.Collections.Generic;
using projecto_incidencias.Models;

namespace projecto_incidencias.Models
{
    public class Documento
    {
      
        public int ID { get; set; }

        public int ID2 { get; set; }

        public string NOMBRE_DEL_DOCUMENTO { get; set; }
        public string NOMBRE { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }

        public string ESTATUS { get; set; }

        public string CALLE { get; set; }

        public int NUMERO { get; set; }

        public string COLONIA { get; set; }
        public string CODIGO_POSTAL { get; set; }

        public int TELEFONO { get; set; }

        public string RFC { get; set; }

        public string OBSERVACIONES{ get; set; }

        public List<prospecto> PROPESTOSS { get; set; }

        public List<Documento> DocumentosSS { get; set; }



    }
}
