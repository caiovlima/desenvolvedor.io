using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AppMvcBasica.Models;
using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    // Repository base, que implementará a interface (contrato) de repositório base (genérico)
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        // Atalhos para podermos operar através do dbset (crud, etc..)
        // assim deixa os métodos menos verboso
        protected readonly MeuDbContext Db; // acesso ao banco
        protected readonly DbSet<TEntity> DbSet; //Querys do entity framework

        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        // declaramos agora o async na assinatura, pois na interface não podemos declarar
        // o await é a resposta do método, ou seja, async na assinatura, e await é o que el espera retornar
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            // retorna uma expressão que você passar, por isso não fica
            // tão verboso um métood de busca
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            //podemos fazer dessa maneira, mas pode ser mais custoso
            //pois iremos ao banco para achar a entidade, e precisamos só do id
            //await DbSet.FindAsync(id)

            //Uma alternativa é declarar um new para a entidade
            //pois é como se ela tivesse "em memória" a informação
            //Declaramos o new(), para que possamos instanciar um novo objeto
            DbSet.Remove(new TEntity { Id = id } );
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }


        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
