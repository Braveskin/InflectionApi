

namespace InflectionApi {

    public static class ApiConstants {

        public const string CONFIG_PI = "inflection_3_pi";
        public const string CONFIG_PRODUCTIVITY = "inflection_3_productivity";

        public const string CONTEXT_TYPE_INSTRUCTION = "Instruction";
        public const string CONTEXT_TYPE_HUMAN = "Human";
        public const string CONTEXT_TYPE_AI = "AI";

        public const string DEFAULT_ENDPOINT_URL = "https://layercake.pubwestus3.inf7ks8.com/external/api/inference";

        public const float DEFAULT_TEMPERATURE = 1.0f;
        public const float MINIMUM_TEMPERATURE = 0.0f;
        public const float MAXIMUM_TEMPERATURE = 1.0f;

        public const int DEFAULT_MAX_TOKENS = 1024;
        public const int MINIMUM_MAX_TOKENS = 1;
        public const int MAXIMUM_MAX_TOKENS = 8000;

        public const int DEFAULT_CONTEXT_LENGTH = 6;
        public const int MINIMUM_CONTEXT_LENGTH = 0;
        public const int MAXIMUM_CONTEXT_LENGTH = 32;

        public const bool DEFAULT_WEB_SEARCH = false;
    }
}
