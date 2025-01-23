using MySql.Data.EntityFramework;
using System.Data.Entity;
using WebApplication1.Model;
using WebApplication1.Helpers;
using System.Collections.Generic;
namespace WebApplication1.Repositories
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))] // Configuração do MySQL para EF6
    public class TarefaRepositorio : DbContext
    {
        // Define o construtor para especificar a string de conexão
        public TarefaRepositorio(string connectionString)
        : base(connectionString)
        {
        }
        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tarefa>().ToTable("Tarefas");
        }
    }
}