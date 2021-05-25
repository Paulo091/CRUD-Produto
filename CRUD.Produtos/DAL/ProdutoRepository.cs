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
            throw new NotImplementedException();
        }

        public TEntity Deletar(TEntity item)
        {
            throw new NotImplementedException();
        }

        public TEntity Inserir(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            _context.SaveChanges();
            return item;
        }

        public List<TEntity> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public TEntity SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
