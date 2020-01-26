using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{

    public interface ICategoriaRepository
    {

        Task SalvarCategoria(List<Livro> livros);
        Categoria RetornaCategoria(string nome);
        Task<IList<Categoria>> GetCategorias();

    }


    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {

        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task SalvarCategoria(List<Livro> livros)
        {

            foreach (var livro in livros)
            {

                if (VerificaDuplicidadeCategoria(livro) == null)
                {
                    Categoria c = new Categoria(livro.Categoria);
                    dbSet.Add(c);
                    await contexto.SaveChangesAsync();
                }

            }


        }

        public Categoria VerificaDuplicidadeCategoria(Livro livro)
        {

            var categoria = dbSet.Where(c => c.Nome == livro.Categoria).SingleOrDefault();

            return categoria;

        }

        public Categoria RetornaCategoria(string nome)
        {
            var categoria = dbSet
                           .Where(p => p.Nome == nome)
                           .SingleOrDefault();

            return categoria;
        }

        public async Task<IList<Categoria>> GetCategorias()
        {
            return await dbSet.ToListAsync();
        }

    }
}
