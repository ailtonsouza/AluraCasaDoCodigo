using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(t => t.Id); //key
            modelBuilder.Entity<Produto>().HasOne(t =>t.Categoria); // produto tem uma categoria

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id); //key
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(t => t.Pedido); // Um pedido tem muitos itens, cada item tem que ter um pedido. 
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cadastro).WithOne(t => t.Pedido).IsRequired(); // Um pedido tem um cadastro e um cadastro tem que ter um pedido.

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id); //key
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido); // Um item pedido tem um pedido
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto); // Um item pedido tem um produto

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id); //key
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido); // Cadastro tem um item pedido
        }
    }
}
