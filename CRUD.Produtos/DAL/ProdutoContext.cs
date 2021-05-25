using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Produtos.DAL
{
    public class ProdutoContext : DbContext
    {
        public DbSet<Models.Produtos> Produtos { get; set; }

        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Produtos>().Property(x => x.NomeProduto).IsRequired();            
            base.OnModelCreating(modelBuilder);
        }
    }
}
