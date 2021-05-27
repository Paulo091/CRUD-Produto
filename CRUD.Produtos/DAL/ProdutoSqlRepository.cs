using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CRUD.Produtos.DAL
{
    public class ProdutoSqlRepository<TEntity> : IDefaultRepository<TEntity> where TEntity : class
    {
        private readonly IConfiguration _configuration;
        private readonly ConexaoSql _conexaoSql;

        public ProdutoSqlRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conexaoSql = new ConexaoSql(_configuration);
        }

        public TEntity Atualizar(TEntity item)
        {
            var ProdutoId = item.GetType().GetProperty("ProdutoId").GetValue(item, null);
            var NomeProduto = item.GetType().GetProperty("NomeProduto").GetValue(item, null);
            var Preco = item.GetType().GetProperty("Preco").GetValue(item, null);

            var query = $"UPDATE Produtos set NomeProduto='{NomeProduto}',Preco={Preco} WHERE ProdutoId = {ProdutoId}";
            _conexaoSql.ExecuteNonQuery(query);

            return item;
        }

        public void Deletar(int id)
        {
            var query = $"DELETE Produtos WHERE ProdutoId={id}";
            _conexaoSql.ExecuteNonQuery(query);
        }

        public TEntity Inserir(TEntity item)
        {
            var NomeProduto = item.GetType().GetProperty("NomeProduto").GetValue(item,null);
            var Preco = item.GetType().GetProperty("Preco").GetValue(item, null);

            var query = $"INSERT INTO Produtos (NomeProduto,Preco) VALUES('{NomeProduto}',{Preco})";
            _conexaoSql.ExecuteNonQuery(query);

            return item;
        }

        public List<TEntity> ListarTodos() 
        {
            List<TEntity> lista = new List<TEntity>();            

            string query = "SELECT * FROM Produtos";

            using(var resultado = _conexaoSql.ExecuteReader(query))
            {
                foreach (DataRow row in resultado.Rows)
                {
                    lista.Add(ObterDadosItem(row));
                }
            }
            return lista;
        }

        public TEntity SelecionarPorId(int id)
        {
            var query = $"SELECT * FROM Produtos Where ProdutoId = {id}";

            TEntity obj = Activator.CreateInstance<TEntity>();

            using (var resultado = _conexaoSql.ExecuteReader(query))
            {                              
                foreach (DataRow row in resultado.Rows)
                {
                    obj = ObterDadosItem(row);
                }                
            }

            return obj;            
        }

        private static TEntity ObterDadosItem(DataRow row)
        {
            var tipoObjeto = typeof(TEntity);
            TEntity obj = Activator.CreateInstance<TEntity>();

            foreach (DataColumn column in row.Table.Columns)
            {
                foreach (PropertyInfo property in tipoObjeto.GetProperties())
                {
                    if (property.Name == column.ColumnName)
                        property.SetValue(obj, row[property.Name],null);
                    continue;
                }
            }

            return obj;
        }
    }
}
