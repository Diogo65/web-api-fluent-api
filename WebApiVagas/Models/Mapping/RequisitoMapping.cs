using System.Data.Entity.ModelConfiguration;
using WebApiVagas.Models.Entities;

namespace WebApiVagas.Models.Mapping
{
    public class RequisitoMapping : EntityTypeConfiguration<Requisito>
    {
        public RequisitoMapping()
        {
            //Nome da tabela
            ToTable("Requisitos");

            //Chave Primária
            HasKey(v => v.Id);

            //As caracterísca p/ cada propriedade
            Property(v => v.Descricao).IsRequired().HasMaxLength(100);

            //Define Relacionamento 1:N entre Requisito e vaga
            //o requisito possui um campo obrigatório (vaga) | uma lista que representa a lista de requisitos de cada vaga
            HasRequired<Vaga>(r => r.Vaga).WithMany(v => v.Requisitos)
                                          .WillCascadeOnDelete();
        }
    }
}