using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApiVagas.Models.Entities
{
    public class Vaga
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal Salario { get; set; }

        public bool Ativa { get; set; } = true;

        public DateTime DataCadastro { get; private set; } = DateTime.Today;
 
        public string LocalTrabalho { get; set; }

        public int EmpresaId { get; set; }

        [JsonIgnore]
        public virtual Empresa Anunciante { get; set; }

        public virtual ICollection<Requisito> Requisitos { get; set; }
    }
}