using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppMvcBasica.Models;

namespace DevIO.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
