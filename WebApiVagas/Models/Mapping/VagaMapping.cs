using System.Data.Entity.ModelConfiguration;
using WebApiVagas.Models.Entities;

namespace WebApiVagas.Models.Mapping
{
    public class VagaMapping : EntityTypeConfiguration<Vaga>
    {
        public VagaMapping()
        {
            //Nome da tabela
            ToTable("Vagas");

            //Chave Primária
            HasKey(v => v.Id);

            //As caracterísca p/ cada propriedade
            Property(v => v.Titulo).IsRequired().HasMaxLength(100);
            Property(v => v.Descricao).IsRequired().HasMaxLength(200);
            Property(v => v.Salario).IsRequired();
            Property(v => v.DataCadastro).IsRequired();
            Property(v => v.LocalTrabalho).IsRequired().HasMaxLength(50);

            //Possui Anunciante do tipo empresa | Enquanto na classe Empresa existe a lista vagas
            HasRequired<Empresa>(v => v.Anunciante).WithMany(e => e.Vagas)
                                                   .HasForeignKey(v => v.EmpresaId)
                                                   .WillCascadeOnDelete();
        }
    }
}