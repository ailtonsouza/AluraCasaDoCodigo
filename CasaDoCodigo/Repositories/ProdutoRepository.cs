using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {


        private readonly ICategoriaRepository categoriaRepository;

        public ProdutoRepository(ApplicationContext contexto,

            ICategoriaRepository categoriaRepository) : base(contexto)
        {

            this.categoriaRepository = categoriaRepository;
        }

        public async Task<IList<Produto>> GetProdutos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IList<Produto>> GetProdutos(string nome)
        {

            return await dbSet.Where(p => p.Nome.Contains(nome) || p.Categoria.Nome.Contains(nome)).ToListAsync();
                       
        }

        public void SaveProdutos(List<Livro> livros)
        {

            categoriaRepository.SalvarCategoria(livros);

            foreach (var livro in livros)
            {

                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {

                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoriaRepository.RetornaCategoria(livro.Categoria)));
                }
            }
            contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
