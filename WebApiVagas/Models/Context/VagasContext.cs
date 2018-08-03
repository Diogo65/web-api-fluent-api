using System.Data.Entity;
using WebApiVagas.Models.Entities;
using WebApiVagas.Models.Mapping;

namespace WebApiVagas.Models.Context
{
    public class VagasContext : DbContext
    {
        public VagasContext() : base("DbVagas")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Chama as configurações criadas nas classes Mapping
            modelBuilder.Configurations.Add<Vaga>(new VagaMapping());
            modelBuilder.Configurations.Add<Empresa>(new EmpresaMapping());
            modelBuilder.Configurations.Add<Requisito>(new RequisitoMapping());
        }

        public DbSet<Vaga> Vagas { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Requisito> Requisitos { get; set; }
    }
}