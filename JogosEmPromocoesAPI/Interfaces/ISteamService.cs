using JogosEmPromocoesAPI.Model;
using System.Threading.Tasks;

namespace JogosEmPromocoesAPI.Interfaces
{
    public interface ISteamService
    {
        public Task<GamesPadraoModel> ListarJogosPromocao(string ordenacao, int pagina);
    }
}
