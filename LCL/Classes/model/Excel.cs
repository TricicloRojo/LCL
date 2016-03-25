using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCL.Clases.model
{
    class Excel
    {
        //Se configuran las clases para poder guardar los datos en un .JSON
        [JsonProperty(PropertyName = "RutaArchivo")]
        public string rutaArchivo { get; set; }

        [JsonProperty(PropertyName = "RutaCarpeta")]
        public string rutaCarpeta { get; set; }

    }


}
