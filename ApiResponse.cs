using System.Text.Json.Serialization;

namespace InflectionApi {

    public class ApiResponse {

        [JsonInclude]
        [JsonPropertyName("created")]
        public float Created { get; private set; }

        [JsonInclude]
        [JsonPropertyName("text")]
        public string Text { get; private set; } = string.Empty;
    }
}