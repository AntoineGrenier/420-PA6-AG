using System.Text.Json.Serialization;

namespace cours9.Modele.Entity
{
    public class Client : IEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
