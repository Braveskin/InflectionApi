using System.Configuration;

namespace InflectionApi {

    public static class Program {

        private static void Main(string[] args) {

            var apiKey = ConfigurationManager.AppSettings["ApiKey"];
            var instruction = ConfigurationManager.AppSettings["Instruction"];
            var contextLength = int.TryParse(ConfigurationManager.AppSettings["ContextLength"], out var contextLengthResult) ? contextLengthResult : DEFAULT_CONTEXT_LENGTH;
            var temperature = float.TryParse(ConfigurationManager.AppSettings["Temperature"], out var temperatureResult) ? temperatureResult : DEFAULT_TEMPERATURE;
            var maxTokens = int.TryParse(ConfigurationManager.AppSettings["MaxTokens"], out var maxTokensResult) ? maxTokensResult : DEFAULT_MAX_TOKENS;
            var webSearch = bool.TryParse(ConfigurationManager.AppSettings["WebSearch"], out var webSearchResult) ? webSearchResult : DEFAULT_WEB_SEARCH;

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ApplicationException("ApiKey value missing from App.config file");

            if (!string.IsNullOrWhiteSpace(instruction))
                Console.WriteLine("Instruction: " + instruction + Environment.NewLine);

            using var chat = new ConsoleChatClient(apiKey);
            chat.Instruction = instruction;
            chat.ContextLength = contextLength;
            chat.Temperature = temperature;
            chat.MaxTokens = maxTokens;
            chat.WebSearch = webSearch;
            chat.Run();
        }
    }
}