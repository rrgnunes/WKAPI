using System;
using System.Collections.Generic;

namespace WKAPI.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produtos = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
