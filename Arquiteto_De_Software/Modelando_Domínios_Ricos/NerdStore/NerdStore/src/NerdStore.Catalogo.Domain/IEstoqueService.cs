using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public interface IEstoqueService : IDisposable
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        //Task<bool> DebitarListaProdutosPedido(ListaProdutosPedido lista);
        Task<bool> ReporEstoque(Guid produtoId, int quantidade);
        //Task<bool> ReporListaProdutosPedido(ListaProdutosPedido lista);
    }
}
