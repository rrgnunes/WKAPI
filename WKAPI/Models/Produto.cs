using System;
using System.Collections.Generic;

namespace WKAPI.Models
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? Idcategoria { get; set; }

        public virtual Categoria? IdcategoriaNavigation { get; set; }
    }
}
