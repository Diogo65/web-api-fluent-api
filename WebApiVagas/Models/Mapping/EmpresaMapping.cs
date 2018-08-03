using System.Data.Entity.ModelConfiguration;
using WebApiVagas.Models.Entities;

namespace WebApiVagas.Models.Mapping
{
    //Classe de mapeadmento de objeto relacional
    //Realiza o mapeamento para Empresa
    public class EmpresaMapping : EntityTypeConfiguration<Empresa>
    {

        public EmpresaMapping()
        {
            //Nome da tabela
            ToTable("Empresas");

            //Chave Primária
            HasKey(v => v.Id);

            //As caracterísca p/ cada propriedade
            Property(v => v.Nome).IsRequired().HasMaxLength(100);
        }
    }
}