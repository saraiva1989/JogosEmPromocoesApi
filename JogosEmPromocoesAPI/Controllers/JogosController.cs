using HtmlAgilityPack;
using JogosEmPromocoesAPI.Helpers;
using JogosEmPromocoesAPI.Interfaces;
using JogosEmPromocoesAPI.Model;
using JogosEmPromocoesAPI.Model.Gog;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JogosEmPromocoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        IEpicService epicService;
        IGogService gogService;
        ISteamService steamService;
        public JogosController(IEpicService epicService, IGogService gogService, ISteamService steamService)
        {
            this.epicService = epicService;
            this.gogService = gogService;
            this.steamService = steamService;
        }

        [HttpGet]
        [Route("epic")]
        public async Task<IActionResult> Epic(string ordenacao, int pagina)
        {
            return Ok(await epicService.ListarJogosPromocao(ordenacao, pagina));
        }

        [HttpGet]
        [Route("comparapreco")]
        public async Task<IActionResult> ComparaPreco(string nome)
        {
            List<Game> games = new List<Game>();
            GamesPadraoModel retorno = new GamesPadraoModel();
            var epic = await epicService.ListarJogosPorNome(nome);
            var gog = await gogService.ListarJogosPorNome(nome);
            var steam = await steamService.ListarJogosPorNome(nome);
            games.AddRange(epic.Games.Take(20));
            games.AddRange(gog.Games.Take(20));
            games.AddRange(steam.Games.Take(20));
            retorno.Games = games;
            return Ok(retorno);
        }

        [HttpGet]
        [Route("gog")]
        public async Task<IActionResult> Gog(string ordenacao, int pagina = 1)
        {
            return Ok(await gogService.ListarJogosPromocao(ordenacao, pagina));
        }

        [HttpGet]
        [Route("steam")]
        public async Task<IActionResult> Steam(string ordenacao, int pagina)
        {
            return Ok(await steamService.ListarJogosPromocao(ordenacao, pagina));
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult ping()
        {
            return Ok(new {ping="ok"});
        }
    }
}
