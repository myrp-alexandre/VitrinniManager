using System.Data.Entity;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Infra.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() 
            : base("AppConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<AppDataContext>(new NullDatabaseInitializer<AppDataContext>());
        }

        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
