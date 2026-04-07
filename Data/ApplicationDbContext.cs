using Microsoft.EntityFrameworkCore;

namespace Sistema_Buffer_BH.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Sistema_Buffer_BH.Models.CaixaModel> Caixa { get; set; }
        public DbSet<Sistema_Buffer_BH.Models.ClientesModel> Clientes { get; set; }
        public DbSet<Sistema_Buffer_BH.Models.EstoqueModel> Estoque {  get; set; }
        public DbSet<Sistema_Buffer_BH.Models.FornecedorModel> Fornecedor { get; set; }
        public DbSet<Sistema_Buffer_BH.Models.FuncionarioModel> Funcionario { get; set; }
    }
}
