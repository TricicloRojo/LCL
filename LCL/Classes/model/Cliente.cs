using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCL.Clases.model
{
    class Cliente{

        [JsonProperty(PropertyName = "Nombre")]

        // No hay encapsulamiento por eso PUBLIC
        public string nombre { get; set; }

        [JsonProperty(PropertyName = "Email")]

        public string email { get; set; }

    }

}
