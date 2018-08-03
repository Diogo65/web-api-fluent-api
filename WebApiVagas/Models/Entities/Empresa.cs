using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApiVagas.Models.Entities
{
    public class Empresa
    {
        //web service RESTful com ASP.NET Web API que contará com as funções de CRUD com relacionamento 1:N.Além disso poderemos também efetuar filtros e ordenação com OData.
        public int Id { get; set; }

        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Vaga> Vagas { get; set; }
    }
}