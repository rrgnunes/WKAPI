using System;
using System.Collections.Generic;

namespace WKApp.Models
{
    public partial class Categoria
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }

        public virtual List<Produto> Produtos { get; set; }

        public Categoria()
        {
            Produtos = new List<Produto>();
        }
    }
}
