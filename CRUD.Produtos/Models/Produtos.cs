using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Produtos.Models
{
    public class Produtos
    {
        [Key]
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public double Preco { get; set; }
    }
}
