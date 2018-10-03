using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoviesInfo.Model
{
    public class EstadosCidades
    {
        [JsonProperty(PropertyName = "estados")]
        public List<Estado> Estados { get; set; }

        public class Estado
        {
            [JsonProperty(PropertyName = "sigla")]
            public string Sigla { get; set; }
            [JsonProperty(PropertyName = "nome")]
            public string Nome { get; set; }
            [JsonProperty(PropertyName = "cidades")]
            public List<string> Cidades { get; set; }
        }


    }
}
