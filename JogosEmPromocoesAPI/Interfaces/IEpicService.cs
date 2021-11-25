using JogosEmPromocoesAPI.Model;
using System.Threading.Tasks;

namespace JogosEmPromocoesAPI.Interfaces
{
    public interface IEpicService
    {
        public Task<GamesPadraoModel> ListarJogosPromocao(string ordenacao, int pagina);
        public Task<GamesPadraoModel> ListarJogosPorNome(string nome);
    }
}
