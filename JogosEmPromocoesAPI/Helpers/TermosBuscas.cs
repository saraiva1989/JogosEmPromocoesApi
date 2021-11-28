using System.Collections.Generic;
using System.Linq;

namespace JogosEmPromocoesAPI.Helpers
{
    public class TermosBuscas
    {
        Dictionary<string, string> termos = new Dictionary<string, string>();
        public TermosBuscas()
        {
            termos.Add("GTA", "Grand Theft Auto");
            termos.Add("BF", "Battlefield");
        }





        public string RetornaNomePorTermo(string termo)
        {
            var pesquisa = termo.Split(' ');
            string termoEncontrado = termos.Where(x => x.Key == pesquisa[0].ToUpper()).FirstOrDefault().Value;
            string retorno = termoEncontrado;

            if (!string.IsNullOrEmpty(termoEncontrado)) { 
                for (int i = 1; i < pesquisa.Count(); i++)
                {
                    retorno += " " + pesquisa[i];
                }
            }
            return retorno == null ? termo : retorno;
        }


    }
}
