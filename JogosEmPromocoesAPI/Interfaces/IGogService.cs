using JogosEmPromocoesAPI.Model;
using System.Threading.Tasks;

namespace JogosEmPromocoesAPI.Interfaces
{
    public interface IGogService
    {
        public Task<GamesPadraoModel> ListarJogosPromocao(string ordenacao, int pagina);
        public Task<GamesPadraoModel> ListarJogosPorNome(string nome);

    }
}
