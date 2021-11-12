using HtmlAgilityPack;
using JogosEmPromocoesAPI.Helpers;
using JogosEmPromocoesAPI.Interfaces;
using JogosEmPromocoesAPI.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogosEmPromocoesAPI.Services
{
    public class SteamService : ISteamService
    {
        public async Task<GamesPadraoModel> ListarJogosPromocao(string ordenacao, int pagina)
        {
            var client = new RestClient(UrlLojas.Steam(ordenacao, pagina * 50));
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            var retorno = JsonConvert.DeserializeObject<SteamOriginalModel>(response.Content);

            GamesPadraoModel gamesPadraoModels = new GamesPadraoModel();
            List<Game> games = new List<Game>();
            decimal quantidadePaginas = Math.Ceiling(Convert.ToDecimal(retorno.total_count) / 50);

            var html = new HtmlDocument();
            html.LoadHtml(retorno.results_html);
            var root = html.DocumentNode;
            var titulos = root.Descendants().Where(x => x.GetAttributeValue("class", "").Equals("title")).ToList();
            var imagens = root.Descendants("img").ToList();
            var linkloja = root.Descendants("a").ToList();
            var precoOriginal = root.Descendants("strike").ToList();
            var precoDesconto = root.Descendants().Where(x => x.GetAttributeValue("class", "").Equals("col search_price discounted responsive_secondrow")).ToList();
            var percentualDisconto = root.Descendants().Where(x => x.GetAttributeValue("class", "").Equals("col search_discount responsive_secondrow")).ToList();


            for (int i = 0; i < titulos.Count(); i++)
            {
                games.Add(new Game
                {
                    Nome = titulos[i].InnerText,
                    Capa = TratarImagem(imagens[i].Attributes["src"].Value),
                    Gratuito = false,
                    LinkLoja = linkloja[i].Attributes["href"].Value,
                    Loja = "Steam",
                    PercentualDesconto = Convert.ToInt32(percentualDisconto[i].InnerText.Replace('%', ' ').Trim()),
                    precoDesconto = precoDesconto[i].InnerText.Split("R$")[2].Trim(),
                    PrecoOriginal = precoOriginal[i].InnerText.Split("R$")[1].Trim(),
                });
            }

            gamesPadraoModels.Games = games;
            gamesPadraoModels.TotalPagina = quantidadePaginas == 1 ? 0 : Convert.ToInt32(quantidadePaginas);
            gamesPadraoModels.Pagina = pagina;

            return gamesPadraoModels;
        }

        private static string TratarImagem(string url)
        {
            var splitUrl = url.Split('/');
            return $"{ splitUrl[0]}//{splitUrl[2]}/{splitUrl[3]}/{splitUrl[4]}/{splitUrl[5]}/header.jpg";
        }
    }
}
