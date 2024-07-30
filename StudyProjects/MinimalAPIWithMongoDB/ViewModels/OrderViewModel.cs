using MinimalAPIWithMongoDB.Domains;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace MinimalAPIWithMongoDB.ViewModels
{
    public class OrderViewModel
    {
        [BsonElement("status")]
        public string? Status { get; set; }

        // Products reference

        [BsonElement("product_id")]
        public List<string>? ProductsId { get; set; }


        // Client reference

        [BsonElement("client_id")]
        public string? ClientId { get; set; }
    }
}
