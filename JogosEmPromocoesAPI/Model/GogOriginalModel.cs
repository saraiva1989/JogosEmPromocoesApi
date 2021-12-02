using System.Collections.Generic;

namespace JogosEmPromocoesAPI.Model.Gog
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class Price
    {
        public decimal amount { get; set; }
        public decimal baseAmount { get; set; }
        public string finalAmount { get; set; }
        public bool isDiscounted { get; set; }
        public int discountPercentage { get; set; }
        public string discountDifference { get; set; }
        public string symbol { get; set; }
        public bool isFree { get; set; }
        public int discount { get; set; }
        public bool isBonusStoreCreditIncluded { get; set; }
        public string bonusStoreCreditAmount { get; set; }
        public string promoId { get; set; }
    }

    public class Product
    {
        public string developer { get; set; }
        public string publisher { get; set; }
        public int? globalReleaseDate { get; set; }
        public bool isTBA { get; set; }
        public Price price { get; set; }
        public bool isDiscounted { get; set; }
        public bool isInDevelopment { get; set; }
        public int id { get; set; }
        public int? releaseDate { get; set; }
        public bool buyable { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public string supportUrl { get; set; }
        public string forumUrl { get; set; }
        public string category { get; set; }
        public string originalCategory { get; set; }
        public int rating { get; set; }
        public int type { get; set; }
        public bool isComingSoon { get; set; }
        public bool isPriceVisible { get; set; }
        public bool isMovie { get; set; }
        public bool isGame { get; set; }
        public string slug { get; set; }
        public bool isWishlistable { get; set; }
        public int ageLimit { get; set; }
    }

    public class GogOriginalModel
    {
        public List<Product> products { get; set; }
        public int page { get; set; }
        public int totalPages { get; set; }
        public string totalResults { get; set; }
        public int totalGamesFound { get; set; }
        public int totalMoviesFound { get; set; }
    }
}
