using System.Text.Json.Serialization;

namespace IntegraBrasilAPI.Dtos
{
    public class EnderecoResponse
    {
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Regiao { get; set; }
        public string Rua { get; set; }
        [JsonIgnore]
        public string Servico { get; set; }
    }
}
