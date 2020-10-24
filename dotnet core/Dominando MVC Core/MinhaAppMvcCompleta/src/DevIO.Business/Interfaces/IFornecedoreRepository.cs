using System;
using System.Threading.Tasks;
using AppMvcBasica.Models;

namespace DevIO.Business.Interfaces
{
    public interface IFornecedoreRepository : IRepository<Fornecedor>
    {
        // Além de conter os métodos base que se encontram em IRepository, vamos adicionar mais dois
        // que são exclusivos para fornecedor
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
