using System.Text.Json.Serialization;

namespace InflectionApi {

    public class ApiMessage(string text, string type) {

        [JsonInclude]
        [JsonPropertyName("text")]
        private string Text { get; set; } = text;

        [JsonInclude]
        [JsonPropertyName("type")]
        private string Type { get; set; } = type;
    }
}