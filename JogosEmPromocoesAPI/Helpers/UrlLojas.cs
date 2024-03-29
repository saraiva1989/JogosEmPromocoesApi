﻿namespace JogosEmPromocoesAPI.Helpers
{
    public class UrlLojas
    {
        public static string Epic(string ordenacao, int pagina)
        {
            string url = string.Empty;
            switch (ordenacao)
            {
                case "popularidade":
                    url = $"https://www.epicgames.com/store/pt-BR/browse?sortBy=releaseDate&sortDir=DESC&priceTier=tierDiscouted&count=40&start={pagina}";
                    break;
                case "preco":
                    url = $"https://www.epicgames.com/store/pt-BR/browse?sortBy=currentPrice&sortDir=ASC&priceTier=tierDiscouted&count=40&start={pagina}";
                    break;
                case "nome":
                    url = $"https://www.epicgames.com/store/pt-BR/browse?sortBy=title&sortDir=ASC&priceTier=tierDiscouted&count=40&start={pagina}";
                    break;
                default:
                    url = $"https://www.epicgames.com/store/pt-BR/browse?sortBy=releaseDate&sortDir=DESC&priceTier=tierDiscouted&count=40&start={pagina}";
                    break;
            }
            return url;
        }

        public static string Gog(string ordenacao, int pagina)
        {
            string url = string.Empty;
            switch (ordenacao)
            {
                case "popularidade":
                    url = $"https://www.gog.com/games/ajax/filtered?hide=dlc&mediaType=game&page={pagina}&price=discounted&sort=popularity";
                    break;
                case "nome":
                    url = $"https://www.gog.com/games/ajax/filtered?hide=dlc&mediaType=game&page={pagina}&price=discounted&sort=title";
                    break;
                default:
                    url = $"https://www.gog.com/games/ajax/filtered?hide=dlc&mediaType=game&page={pagina}&price=discounted&sort=popularity";
                    break;
            }
            return url;
        }

        public static string Steam(string ordenacao, int pagina)
        {
            string url = string.Empty;
            switch (ordenacao)
            {
                case "popularidade":
                    url = $"https://store.steampowered.com/search/results/?query&start={pagina}&count=50&dynamic_data=&sort_by=_ASC&category1=998&snr=1_7_7_2300_7&specials=1&infinite=1";
                    break;
                case "preco":
                    url = $"https://store.steampowered.com/search/results/?query&start={pagina}&count=50&dynamic_data=&sort_by=Price_ASC&category1=998&snr=1_7_7_2300_7&specials=1&infinite=1";
                    break;
                case "nome":
                    url = $"https://store.steampowered.com/search/results/?query&start={pagina}&count=50&dynamic_data=&sort_by=Name_ASC&category1=998&snr=1_7_7_2300_7&specials=1&infinite=1";
                    break;
                default:
                    url = $"https://store.steampowered.com/search/results/?query&start={pagina}&count=50&dynamic_data=&sort_by=_ASC&category1=998&snr=1_7_7_2300_7&specials=1&infinite=1";
                    break;
            }
            return url;
        }

        public static string EpicNome(string nome)
        {
            return $"https://www.epicgames.com/graphql?operationName=searchStoreQuery&variables=%7B%22allowCountries%22:%22BR%22,%22category%22:%22games%2Fedition%2Fbase%7Csoftware%2Fedition%2Fbase%7Ceditors%7Cbundles%2Fgames%22,%22count%22:40,%22country%22:%22BR%22,%22keywords%22:%22{nome}%22,%22locale%22:%22pt-BR%22,%22sortBy%22:%22relevancy%22,%22sortDir%22:%22DESC%22,%22tag%22:%22%22,%22withPrice%22:true%7D&extensions=%7B%22persistedQuery%22:%7B%22version%22:1,%22sha256Hash%22:%220304d711e653a2914f3213a6d9163cc17153c60aef0ef52279731b02779231d2%22%7D%7D";
        }

        public static string GogNome(string nome)
        {
            return $"https://www.gog.com/games/ajax/filtered?hide=dlc&mediaType=game&page=1&search={nome}&sort=popularity";
        }

        public static string SteamNome(string nome)
        {
            return $"https://store.steampowered.com/search/results/?query&start=0&count=50&dynamic_data=&sort_by=_ASC&term={nome}&snr=1_7_7_151_7&category1=998&infinite=1";
        }
    }
}
