using System;
using System.Collections.Generic;

namespace JogosEmPromocoesAPI.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class KeyImage
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Seller
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Tag
    {
        public string id { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string @namespace { get; set; }
    }

    public class CustomAttribute
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Category
    {
        public string path { get; set; }
    }

    public class Mapping
    {
        public string pageSlug { get; set; }
        public string pageType { get; set; }
    }

    public class CatalogNs
    {
        public List<Mapping> mappings { get; set; }
    }

    public class OfferMapping
    {
        public string pageSlug { get; set; }
        public string pageType { get; set; }
    }

    public class CurrencyInfo
    {
        public int decimals { get; set; }
    }

    public class FmtPrice
    {
        public string originalPrice { get; set; }
        public string discountPrice { get; set; }
        public string intermediatePrice { get; set; }
    }

    public class TotalPrice
    {
        public int discountPrice { get; set; }
        public int originalPrice { get; set; }
        public int voucherDiscount { get; set; }
        public int discount { get; set; }
        public string currencyCode { get; set; }
        public CurrencyInfo currencyInfo { get; set; }
        public FmtPrice fmtPrice { get; set; }
    }

    public class DiscountSetting
    {
        public string discountType { get; set; }
    }

    public class AppliedRule
    {
        public string id { get; set; }
        public DateTime endDate { get; set; }
        public DiscountSetting discountSetting { get; set; }
    }

    public class LineOffer
    {
        public List<AppliedRule> appliedRules { get; set; }
    }

    public class Price
    {
        public TotalPrice totalPrice { get; set; }
        public List<LineOffer> lineOffers { get; set; }
    }

    public class Element
    {
        public string title { get; set; }
        public string id { get; set; }
        public string @namespace { get; set; }
        public string description { get; set; }
        public DateTime effectiveDate { get; set; }
        public List<KeyImage> keyImages { get; set; }
        public int currentPrice { get; set; }
        public Seller seller { get; set; }
        public string productSlug { get; set; }
        public string urlSlug { get; set; }
        public object url { get; set; }
        public List<Tag> tags { get; set; }
        public List<Item> items { get; set; }
        public List<CustomAttribute> customAttributes { get; set; }
        public List<Category> categories { get; set; }
        public CatalogNs catalogNs { get; set; }
        public List<OfferMapping> offerMappings { get; set; }
        public string developerDisplayName { get; set; }
        public string publisherDisplayName { get; set; }
        public Price price { get; set; }
        public DateTime releaseDate { get; set; }
        public DateTime? pcReleaseDate { get; set; }
    }

    public class Paging
    {
        public int count { get; set; }
        public int total { get; set; }
    }

    public class SearchStore
    {
        public List<Element> elements { get; set; }
        public Paging paging { get; set; }
    }

    public class Catalog
    {
        public SearchStore searchStore { get; set; }
    }

    public class Data
    {
        public Catalog Catalog { get; set; }
    }

    public class Extensions
    {
    }

    public class EpicOriginalModel
    {
        public Data data { get; set; }
        public Extensions extensions { get; set; }
    }
}
