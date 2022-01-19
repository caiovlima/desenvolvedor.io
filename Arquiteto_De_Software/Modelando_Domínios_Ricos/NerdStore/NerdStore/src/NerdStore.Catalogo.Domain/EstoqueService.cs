using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;

        public EstoqueService(IProdutoRepository produtoRepository,
            IMediatrHandler bus
            )
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            if (!await DebitarItemEstoque(produtoId, quantidade)) return false;

            return await _produtoRepository.UnitOfWork.Commit();
        }

        //public async Task<bool> DebitarListaProdutosPedido(ListaProdutosPedido lista)
        //{
        //    foreach (var item in lista.Itens)
        //    {
        //        if (!await DebitarItemEstoque(item.Id, item.Quantidade)) return false;
        //    }

        //    return await _produtoRepository.UnitOfWork.Commit();
        //}

        private async Task<bool> DebitarItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            //if (!produto.PossuiEstoque(quantidade))
            //{
            //    await __bus.PublicarNotificacao(new DomainNotification("Estoque", $"Produto - {produto.Nome} sem estoque"));
            //    return false;
            //}

            produto.DebitarEstoque(quantidade);

            // TODO: 10 pode ser parametrizavel em arquivo de configuração
            if (produto.QuantidadeEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);
            return true;
        }

        //public async Task<bool> ReporListaProdutosPedido(ListaProdutosPedido lista)
        //{
        //    foreach (var item in lista.Itens)
        //    {
        //        await ReporItemEstoque(item.Id, item.Quantidade);
        //    }

        //    return await _produtoRepository.UnitOfWork.Commit();
        //}

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var sucesso = await ReporItemEstoque(produtoId, quantidade);

            if (!sucesso) return false;

            return await _produtoRepository.UnitOfWork.Commit();
        }

        private async Task<bool> ReporItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;
            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return true;
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
