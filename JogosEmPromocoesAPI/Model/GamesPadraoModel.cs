using System.Collections.Generic;

namespace JogosEmPromocoesAPI.Model
{
    public class GamesPadraoModel
    {
        public List<Game> Games { get; set; }
        public int Pagina { get; set; }
        public int Total { get; set; }
    }

    public class Game
    {
        public string Nome { get; set; }
        public string Capa { get; set; }
        public decimal PrecoOriginal { get; set; }
        public decimal precoDesconto { get; set; }
        public int PercentualDesconto { get; set; }
        public string LinkLoja { get; set; }
        public string Loja { get; set; }
        public bool Gratuito { get; set; }
        public int Position { get; set; }
        public string TipoGratuito { get; set; }
    }
}
