using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AppMvcBasica.Models;

namespace DevIO.Business.Interfaces
{
    // Interface genérica, que prove métodos base para qualquer interface. 
    // por isso ele implementa uma entidade genérica que nomeamos de TEntity
    // IDisposable gerencia recursos(memória etc..)
    // E só pode ser utilizado, caso a classe seja um extend de Entity, que é nossa
    // classe básica

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        // Iremos implementar desde o começo questõs assíncronas, por isso utilizar o Task na assinatura
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
