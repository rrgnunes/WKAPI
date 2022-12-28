using Microsoft.AspNetCore.Mvc;
using WKApp.Models;

namespace WKApp.Interfaces
{
    public interface ICategoria
    {


        List<Categoria> GetCategorias();
        Categoria GetCategoria(int id);
        Categoria PutCategoria(int id, Categoria categoria);
        Categoria PostCategoria(Categoria categoria);
        Categoria DeleteCategoria(int id);
        bool CategoriaExists(int id);
    }
}
