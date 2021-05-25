using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Produtos.DAL
{
    public interface IDefaultRepository<TEntity> where TEntity : class
    {
        public List<TEntity> ListarTodos();
        public TEntity SelecionarPorId(int id);
        public TEntity Inserir(TEntity item);
        public TEntity Atualizar(TEntity item);
        public TEntity Deletar(TEntity item);
    }
}
