using System.Collections.Generic;

namespace JogosEmPromocoesAPI.Model
{
    public class GamesPadraoModel
    {
        public List<Game> Games { get; set; }
        public int Pagina { get; set; }
        public int TotalPagina { get; set; }
    }

    public class Game
    {
        private string nome;

        public string Nome { get => nome; set => nome = value.ToUpper()
                .Replace("™", "")
                .Replace(":", "")
                .Trim(); }
        public string Capa { get; set; }
        public string PrecoOriginal { get; set; }
        public string precoDesconto { get; set; }
        public int PercentualDesconto { get; set; }
        public string LinkLoja { get; set; }
        public string Loja { get; set; }
        public bool Gratuito { get; set; }
        public int Position { get; set; }
        public string TipoGratuito { get; set; }
    }
}
