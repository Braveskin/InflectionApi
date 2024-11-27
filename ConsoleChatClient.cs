

namespace InflectionApi {

    public class ConsoleChatClient(string apiKey) : ChatClientBase(apiKey) {

        protected override string? GetHumanInput() {
            Console.Write("You: ");
            var humanInput = Console.ReadLine();
            Console.WriteLine("");
            return humanInput;
        }

        protected override void OnAiResponse(string text) {
            Console.WriteLine("AI: " + text + "\n");
        }
    }
}