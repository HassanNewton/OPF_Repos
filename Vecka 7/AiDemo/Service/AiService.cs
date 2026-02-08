namespace AiDemo.Service
{
    public class AiService
    {
        private readonly HttpClient _http;

        public AiService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("http://localhost:11434");
        }

        public async Task<string> AskAsync(string prompt)
        {
            var request = new
            {
                model = "phi3",
                prompt = prompt,
                stream = false
            };

            var response = await _http.PostAsJsonAsync("/api/generate", request);
            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();

            return result.response;
        }
    }

    public class OllamaResponse
    {
        public string response { get; set; }
    }
}

