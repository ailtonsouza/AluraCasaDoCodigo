using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {

        public BuscaDeProdutosViewModel(IList<Produto> produtos, IList<Categoria> categorias)
        {
            this.Produtos = produtos;
            this.Categorias = categorias;
        }

        public BuscaDeProdutosViewModel()
        {
          
        }



        public IList<Produto> Produtos { get; }
        public IList<Categoria> Categorias { get; }
        public string pesquisa { get; set; }

    }
}
