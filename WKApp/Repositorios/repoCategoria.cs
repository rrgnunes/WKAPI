using Newtonsoft.Json;
using System.Text;
using WKApp.Interfaces;
using WKApp.Models;

namespace WKApp.Repositorios
{
    public class repoCategoria : ICategoria
    {
        private readonly string sURL = "https://localhost:7086/api/";

        public Categoria DeleteCategoria(int id)
        {
            var CategoriaRetorno = new Categoria();
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = client.DeleteAsync(sURL + "Categorias/" + id.ToString());
                    resposta.Wait();
                    CategoriaRetorno = JsonConvert.DeserializeObject<Categoria>(resposta.Result.ToString());
                }
            }
            catch
            {

            }

            return CategoriaRetorno;
        }

        public Categoria GetCategoria(int id)
        {
            var retornoCategoria = new Categoria();
            try
            {
                using (var client = new HttpClient())
                {

                    var resposta = client.GetStringAsync(sURL + "Categorias/" + id.ToString());
                    resposta.Wait();
                    retornoCategoria = JsonConvert.DeserializeObject<Categoria>(resposta.Result);

                }
            }
            catch
            {

            }

            return retornoCategoria;
        }

        public List<Categoria> GetCategorias()
        {
            var retornoCategoria = new List<Categoria>();
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = client.GetStringAsync(sURL + "Categorias");
                    resposta.Wait();

                    retornoCategoria = JsonConvert.DeserializeObject<Categoria[]>(resposta.Result).ToList();
                }
            }
            catch
            {

            }

            return retornoCategoria;
        }

        public Categoria PostCategoria(Categoria Categoria)
        {
            var CategoriaPost = new Categoria();
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(Categoria, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var resposta = client.PostAsync(sURL + "Categorias", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        CategoriaPost = JsonConvert.DeserializeObject<Categoria>(retorno.Result);
                    }
                }
            }
            catch
            {

            }

            return CategoriaPost;

        }

        public bool CategoriaExists(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria PutCategoria(int id, Categoria Categoria)
        {
            var CategoriaPost = new Categoria();
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(Categoria, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var resposta = client.PutAsync(sURL + "Categorias/" + id.ToString(), content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        CategoriaPost = JsonConvert.DeserializeObject<Categoria>(retorno.Result);
                    }
                }
            }
            catch
            {

            }

            return CategoriaPost;
        }

 
    }
}
