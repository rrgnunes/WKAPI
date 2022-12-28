using Microsoft.AspNetCore.Mvc;
using WKApp.Models;

namespace WKApp.Interfaces
{
    public interface IProduto
    {
        List<Produto> GetProdutos();
        Produto GetProduto(int id);
        Produto PutProduto(int id, Produto produto);
        Produto PostProduto(Produto produto);
        Produto DeleteProduto(int id);
        bool ProdutoExists(int id);
    }
}
