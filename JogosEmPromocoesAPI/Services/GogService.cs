﻿using JogosEmPromocoesAPI.Helpers;
using JogosEmPromocoesAPI.Interfaces;
using JogosEmPromocoesAPI.Model;
using JogosEmPromocoesAPI.Model.Gog;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogosEmPromocoesAPI.Services
{
    public class GogService : IGogService
    {
        public async Task<GamesPadraoModel> ListarJogosPorNome(string nome)
        {
            var client = new RestClient(UrlLojas.GogNome(nome.Replace(' ', '+')));
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);
            var retorno = JsonConvert.DeserializeObject<GogOriginalModel>(response.Content);
            return TratarDados(0, retorno);
        }

        public async Task<GamesPadraoModel> ListarJogosPromocao(string ordenacao, int pagina)
        {
            var client = new RestClient(UrlLojas.Gog(ordenacao, pagina));
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "gog_lc=BR_BRL_en-US");
            IRestResponse response = await client.ExecuteAsync(request);
            var retorno = JsonConvert.DeserializeObject<GogOriginalModel>(response.Content);
            return TratarDados(pagina, retorno);
        }

        private static GamesPadraoModel TratarDados(int pagina, GogOriginalModel retorno)
        {
            GamesPadraoModel gamesPadraoModels = new GamesPadraoModel();
            List<Game> games = new List<Game>();

            foreach (var item in retorno.products)
            {
                games.Add(new Game
                {
                    Capa = $"https:{item.image}_product_tile_256.jpg",
                    Gratuito = item.price.isFree,
                    LinkLoja = $"https://gog.com{item.url}",
                    Loja = "GOG",
                    Nome = item.title,
                    PercentualDesconto = item.price.discountPercentage,
                    Position = 0,
                    precoDesconto = item.price.amount.ToString("n2"),
                    PrecoOriginal = item.price.baseAmount.ToString("n2")
                });
            }

            gamesPadraoModels.Games = games;
            gamesPadraoModels.TotalPagina = retorno.totalPages;
            gamesPadraoModels.Pagina = pagina;

            return gamesPadraoModels;
        }
    }
}
