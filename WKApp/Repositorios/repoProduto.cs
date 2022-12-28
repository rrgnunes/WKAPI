using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.Json.Serialization;
using WKApp.Interfaces;
using WKApp.Models;

namespace WKApp.Repositorios
{

    public class repoProduto : IProduto
    {
        private readonly string sURL = "https://localhost:7086/api/";

        public Produto DeleteProduto(int id)
        {
            var produtoRetorno = new Produto();
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = client.DeleteAsync(sURL + "Produtos/" + id.ToString());
                    resposta.Wait();
                    produtoRetorno = JsonConvert.DeserializeObject<Produto>(resposta.Result.ToString());
                }
            }
            catch
            {

            }

            return produtoRetorno;
        }

        public Produto GetProduto(int id)
        {
            var retornoProduto = new Produto();
            try
            {
                using (var client = new HttpClient())
                {

                    var resposta = client.GetStringAsync(sURL + "Produtos/" + id.ToString());
                    resposta.Wait();
                    retornoProduto = JsonConvert.DeserializeObject<Produto>(resposta.Result);

                }
            }
            catch
            {

            }

            return retornoProduto;
        }

        public List<Produto> GetProdutos()
        {
            var retornoProduto = new List<Produto>();
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = client.GetStringAsync(sURL + "Produtos");
                    resposta.Wait();

                    retornoProduto = JsonConvert.DeserializeObject<Produto[]>(resposta.Result).ToList();
                }
            }
            catch
            {

            }

            return retornoProduto;
        }

        public Produto PostProduto(Produto produto)
        {
            var produtoPost = new Produto();
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(produto, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var resposta = client.PostAsync(sURL + "Produtos", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoPost = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                }
            }
            catch
            {

            }

            return produtoPost;

        }

        public bool ProdutoExists(int id)
        {
            throw new NotImplementedException();
        }

        public Produto PutProduto(int id, Produto produto)
        {
            var produtoPost = new Produto();
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(produto, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var resposta = client.PutAsync(sURL + "Produtos/" + id.ToString(), content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoPost = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                }
            }
            catch
            {

            }

            return produtoPost;
        }
    }
}
