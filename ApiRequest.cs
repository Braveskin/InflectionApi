using System.Text.Json.Serialization;

namespace InflectionApi {

    public class ApiRequest {

        [JsonInclude]
        [JsonPropertyName("context")]
        private List<ApiMessage> Context { get; set; } = [];

        [JsonInclude]
        [JsonPropertyName("config")]
        private string Config { get; set; } = CONFIG_PRODUCTIVITY;

        [JsonInclude]
        [JsonPropertyName("temperature")]
        private float Temperature { get; set; } = DEFAULT_TEMPERATURE;

        [JsonInclude]
        [JsonPropertyName("max_tokens")]
        private float MaxTokens { get; set; } = DEFAULT_MAX_TOKENS;

        [JsonInclude]
        [JsonPropertyName("web_search")]
        private bool WebSearch { get; set; } = DEFAULT_WEB_SEARCH;

        public ApiRequest AddInstruction(string text) => AddContext(text, CONTEXT_TYPE_INSTRUCTION);

        public ApiRequest AddHumanText(string text) => AddContext(text, CONTEXT_TYPE_HUMAN);

        public ApiRequest AddAiText(string text) => AddContext(text, CONTEXT_TYPE_AI);

        private ApiRequest AddContext(string text, string type) {

            Context.Add(new ApiMessage(text, type));

            return this;
        }

        public ApiRequest WithConfig(ApiConifgOption configOption) {

            Config = configOption switch {
                ApiConifgOption.Pi => CONFIG_PI,
                ApiConifgOption.Productivity => CONFIG_PRODUCTIVITY,
                _ => throw new ArgumentException("Unknown API Config Option: " + configOption.ToString()),
            };

            return this;
        }

        public ApiRequest WithTemperature(float temperature) {

            Temperature = temperature;

            return this;
        }

        public ApiRequest WithMaxTokens(int maxTokens) {

            MaxTokens = maxTokens;

            return this;
        }

        public ApiRequest WithWebSearch(bool webSearch) {

            WebSearch = webSearch;

            return this;
        }
    }
}