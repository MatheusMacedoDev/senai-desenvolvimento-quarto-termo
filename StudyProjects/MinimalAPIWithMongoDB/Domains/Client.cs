using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MinimalAPIWithMongoDB.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("user_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonElement("cpf")]
        public string? CPF { get; set; }

        [BsonElement("phone_number")]
        public string? PhoneNumber { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        public Dictionary<string, string>? AdditionalAttributes { get; set; }

        public Client()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}
