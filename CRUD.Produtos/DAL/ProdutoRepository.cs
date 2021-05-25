using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Produtos.DAL
{
    public class ProdutoRepository<TEntity> : IDefaultRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }
        public TEntity Atualizar(TEntity item)
        {
            _context.Set<TEntity>().Update(item);
            _context.SaveChanges();
            return item;
        }

        public void Deletar(int id)
        {
            TEntity item = SelecionarPorId(id);
            if (item is null)
                return;

            _context.Set<TEntity>().Remove(item);
            _context.SaveChanges();
        }

        public TEntity Inserir(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            _context.SaveChanges();
            return item;
        }

        public List<TEntity> ListarTodos()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity SelecionarPorId(int id)
        {
            return _context.Find<TEntity>(id);
        }
    }
}
