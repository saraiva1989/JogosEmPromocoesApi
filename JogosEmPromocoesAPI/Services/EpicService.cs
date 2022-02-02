using HtmlAgilityPack;
using JogosEmPromocoesAPI.Helpers;
using JogosEmPromocoesAPI.Interfaces;
using JogosEmPromocoesAPI.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace JogosEmPromocoesAPI.Services
{
    public class EpicService : IEpicService
    {
        public async Task<GamesPadraoModel> ListarJogosPorNome(string nome)
        {
            var client = new RestClient(UrlLojas.EpicNome(nome));
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);
            var retorno = JsonConvert.DeserializeObject<EpicOriginalModel>(response.Content);
            return TratarDados(0, response.Content);
        }

        public async Task<GamesPadraoModel> ListarJogosPromocao(string ordenacao, int pagina)
        {
            var client = new RestClient(UrlLojas.Epic(ordenacao, pagina * 40));
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);
            //var retorno = JsonConvert.DeserializeObject<EpicOriginalModel>(response.Content);
            if (string.IsNullOrEmpty(response.Content))
                return null;
            return TratarDados(pagina, response.Content);
        }

        private static GamesPadraoModel TratarDados(int pagina, string retorno)
        {
            GamesPadraoModel gamesPadraoModels = new GamesPadraoModel();
            List<Game> games = new List<Game>();
            decimal quantidadePaginas = 2; //Math.Ceiling(Convert.ToDecimal(retorno.total_count) / 50);



            var html = new HtmlDocument();
            html.LoadHtml(retorno);
            var root = html.DocumentNode;

            var paginas = html.DocumentNode.SelectNodes("//div[@data-component='InnerBodyWithRightSidebar']//a[@class='css-1ns6940']");
            pagina = paginas != null && paginas.Count() > 0 ? Convert.ToInt32(paginas.Where(x => x.InnerText != "").LastOrDefault().InnerText) : 0;
            var titulos = html.DocumentNode.SelectNodes("//div[@data-component='InnerBodyWithRightSidebar']//span[@class='css-2ucwu']");
            var disconto = html.DocumentNode.SelectNodes("//div[@data-component='InnerBodyWithRightSidebar']//div[@class='css-b0xoos']");
            var valores = html.DocumentNode.SelectNodes("//div[@data-component='InnerBodyWithRightSidebar']//div[@class='css-1rcj98u']");
            var valoresDisconto = html.DocumentNode.SelectNodes("//div[@data-component='InnerBodyWithRightSidebar']//span[@class='css-z3vg5b']");
            var linkloja = html.DocumentNode.SelectNodes("//div[@data-component='InnerBodyWithRightSidebar']//a[@class='css-1jx3eyg']");
            var imagens = html.DocumentNode.SelectNodes("//div[@data-component='InnerBodyWithRightSidebar']//img[@class='css-10w32v9']");


       

            for (int i = 0; i < titulos.Count(); i++)
            {
                bool valoresVazio = String.IsNullOrEmpty(valores[i].InnerText.Trim());
                try
                {
                    games.Add(new Game
                    {
                        Nome = titulos[i].InnerText,
                        Capa = imagens[i].Attributes["data-image"].Value,
                        Gratuito = false,
                        LinkLoja = $"https://www.epicgames.com{ linkloja[i].Attributes["href"].Value }",
                        Loja = "Epic",
                        PercentualDesconto = Convert.ToInt32(disconto[i].InnerText.Replace("%", "").Replace("-", "")),
                        precoDesconto = valoresVazio ? "indefinido" : valoresDisconto[i].InnerText.Split("R$")[1].Trim(),
                        PrecoOriginal = valoresVazio ? "indefinido" : valores[i].InnerText.Split("R$")[1].Trim(),
                    }) ;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            gamesPadraoModels.Games = games;
            gamesPadraoModels.TotalPagina = quantidadePaginas == 1 ? 0 : Convert.ToInt32(quantidadePaginas);
            gamesPadraoModels.Pagina = pagina;

            return gamesPadraoModels;
        }



        private static GamesPadraoModel TratarDadosw(int pagina, EpicOriginalModel retorno)
        {
            GamesPadraoModel gamesPadraoModels = new GamesPadraoModel();
            List<Game> games = new List<Game>();

            decimal quantidadePaginas = Math.Ceiling(Convert.ToDecimal(retorno.data.Catalog.searchStore.paging.total) / 40);

            var elementos = retorno.data.Catalog.searchStore.elements;
            foreach (var element in elementos)
            {
                try
                {
                    decimal precoOriginal = Convert.ToDecimal(element.price.totalPrice.fmtPrice.originalPrice.Replace("R$ ", ""));
                    decimal precoDesconto = Convert.ToDecimal(element.price.totalPrice.fmtPrice.discountPrice.Replace("R$ ", ""));
                    int TotalDesconto = 0;
                    if (precoOriginal != 0)
                        TotalDesconto = Convert.ToInt32((precoDesconto * 100) / precoOriginal - 1 * 100);

                    games.Add(
                    new Game
                    {
                        Nome = element.title,
                        Capa = element.keyImages.Where(x => x.type == "OfferImageTall").FirstOrDefault().url,
                        Gratuito = false,
                        LinkLoja = $"https://www.epicgames.com/store/pt-BR/p/{element.catalogNs.mappings.Where(x => x.pageType == "productHome").FirstOrDefault().pageSlug}",
                        Loja = "Epic",
                        Position = 0,
                        PrecoOriginal = element.price.totalPrice.fmtPrice.originalPrice.Replace("R$ ", ""),
                        precoDesconto = element.price.totalPrice.fmtPrice.discountPrice.Replace("R$ ", ""),
                        PercentualDesconto = TotalDesconto
                    });
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            gamesPadraoModels.Games = games;
            gamesPadraoModels.TotalPagina = quantidadePaginas == 1 ? 0 : Convert.ToInt32(quantidadePaginas);
            gamesPadraoModels.Pagina = pagina;
            return gamesPadraoModels;
        }
    }
}
