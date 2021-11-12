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
        public async Task<GamesPadraoModel> ListarJogosPromocao(string ordenacao, int pagina)
        {
            var client = new RestClient(UrlLojas.Epic(ordenacao, pagina*40));
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);
            var retorno = JsonConvert.DeserializeObject<EpicOriginalModel>(response.Content);

            GamesPadraoModel gamesPadraoModels = new GamesPadraoModel();
            List<Game> games = new List<Game>();

            decimal quantidadePaginas = Math.Ceiling(Convert.ToDecimal(retorno.data.Catalog.searchStore.paging.total) / 40);


            var elementos = retorno.data.Catalog.searchStore.elements;
            foreach (var element in elementos)
            {
                decimal precoOriginal = Convert.ToDecimal(element.price.totalPrice.fmtPrice.originalPrice.Replace("R$ ", ""));
                decimal precoDesconto = Convert.ToDecimal(element.price.totalPrice.fmtPrice.discountPrice.Replace("R$ ", ""));

                int TotalDesconto = Convert.ToInt32((precoDesconto * 100) / precoOriginal - 1 * 100);

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

            gamesPadraoModels.Games = games;
            gamesPadraoModels.TotalPagina = quantidadePaginas == 1 ? 0 : Convert.ToInt32(quantidadePaginas);
            gamesPadraoModels.Pagina = pagina;
            return gamesPadraoModels;
        }
    }
}
