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
        [Required(ErrorMessage = "O campo NomeProduto é obrigatório")]
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "O campo Preco é obrigatório")]
        public double Preco { get; set; }
    }
}
