
namespace InflectionApi {

    public abstract class ChatClientBase(string apiKey) : ApiClient(apiKey) {

        private string? instruction;

        private int contextLength = DEFAULT_CONTEXT_LENGTH;

        private float temperature = DEFAULT_TEMPERATURE;

        private int maxTokens = DEFAULT_MAX_TOKENS;

        private bool webSearch = DEFAULT_WEB_SEARCH;

        private readonly Queue<ChatText> chatTextQueue = [];

        public string? Instruction {
            get { return instruction; }
            set { instruction = value; }
        }

        public int ContextLength {
            get { return contextLength; }
            set {
                if (value < MINIMUM_CONTEXT_LENGTH || value > MAXIMUM_CONTEXT_LENGTH)
                    throw new ArgumentOutOfRangeException(nameof(ContextLength), $"ContextLength must be betweeb {MINIMUM_CONTEXT_LENGTH} and {MAXIMUM_CONTEXT_LENGTH} inclusively.");
                contextLength = value;
            }
        }

        public float Temperature {
            get { return temperature; }
            set {
                if (value < MINIMUM_TEMPERATURE || value > MAXIMUM_TEMPERATURE)
                    throw new ArgumentOutOfRangeException(nameof(Temperature), $"Temperature must be between {MINIMUM_TEMPERATURE} and {MAXIMUM_TEMPERATURE} inclusively.");
                temperature = value;
            }
        }

        public int MaxTokens {
            get { return maxTokens; }
            set {
                if (value < MINIMUM_MAX_TOKENS || value > MAXIMUM_MAX_TOKENS)
                    throw new ArgumentOutOfRangeException(nameof(MaxTokens), $"MaxTokens must be between {MINIMUM_MAX_TOKENS} and {MAXIMUM_MAX_TOKENS} inclusively.");
                maxTokens = value;
            }
        }

        public bool WebSearch {
            get { return webSearch; }
            set { webSearch = value; }
        }

        protected abstract string? GetHumanInput();

        protected abstract void OnAiResponse(string text);

        public void Run() {
            
            while (true) {

                while (chatTextQueue.Count > contextLength)
                    chatTextQueue.Dequeue();

                var humanInput = GetHumanInput();

                if (string.IsNullOrWhiteSpace(humanInput))
                    break;

                chatTextQueue.Enqueue(new ChatText(isAi: false, humanInput));

                var request = BuildRequest();
                var response = GetResponse(request);

                if (response == null)
                    break;

                chatTextQueue.Enqueue(new ChatText(isAi: true, response.Text));

                OnAiResponse(response.Text);
            }
        }

        private ApiRequest BuildRequest() {

            var request = new ApiRequest()
                .WithTemperature(temperature)
                .WithMaxTokens(maxTokens)
                .WithWebSearch(webSearch);

            if (!string.IsNullOrWhiteSpace(instruction))
                request.AddInstruction(instruction);

            foreach (var chatText in chatTextQueue) {
                if (chatText.IsAi)
                    request.AddAiText(chatText.Text);
                else
                    request.AddHumanText(chatText.Text);
            }

            return request;
        }

        private class ChatText(bool isAi, string text) {
            public bool IsAi = isAi;
            public string Text = text;
        }
    }
}