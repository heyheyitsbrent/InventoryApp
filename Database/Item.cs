namespace InventoryApp.Database
{
    using System;
    using Newtonsoft.Json;
    
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "room")]
        public string Room { get; set; }

        [JsonProperty(PropertyName = "section")]
        public string Section { get; set; }

        [JsonProperty(PropertyName = "subsection")]
        public string Subsection { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "subcategory")]
        public string Subcategory { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public double? Quantity { get; set; }
    
        [JsonProperty(PropertyName = "purchaseDate")]
        public DateTime? PurchaseDate { get; set; }

        [JsonProperty(PropertyName = "bestBeforeDate")]
        public DateTime? BestBeforeDate { get; set; }
    }
}