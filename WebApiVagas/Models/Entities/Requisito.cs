using Newtonsoft.Json;

namespace WebApiVagas.Models.Entities
{
    public class Requisito
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        [JsonIgnore]
        public virtual Vaga Vaga { get; set; }
    }
}