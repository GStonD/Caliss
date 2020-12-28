using System;
using System.Collections;
using System.Collections.Generic;
using projecto_incidencias.Models;

namespace projecto_incidencias.Models
{
    public class prospecto
    {
       public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }

        public string CALLE{ get; set; }

        public int NUMERO { get; set; }

        public string COLONIA { get; set; }

        public string CODIGO_POSTAL { get; set; }

        public int TELEFONO { get; set; }

        public string RFC { get; set; }

        public string DOCUMENTO { get; set; }

        public List<Documento> Documentoss { get; set; }


    }
}



