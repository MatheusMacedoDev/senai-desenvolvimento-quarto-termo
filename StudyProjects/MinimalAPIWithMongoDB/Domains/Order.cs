using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MinimalAPIWithMongoDB.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateOnly? Date { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        // Products reference

        [BsonElement("product_id")]
        public List<string>? ProductsId { get; set; }
        public List<Product>? Products { get; set; }

        // Client reference

        [BsonElement("client_id")]
        public string? ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
