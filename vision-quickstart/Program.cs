using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;
using OpenAI.Images;
using static System.Environment;

string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? "https://hassantest.openai.azure.com/";
string key = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY") ?? "AzGZhC6ykqBQlqmsMOssg2KielM6D7VXVojRsEbjw8R3X2za9DDWJQQJ99CAACfhMk5XJ3w3AAABACOGTtBR";

// Use the recommended keyless credential instead of the AzureKeyCredential credential.
AzureOpenAIClient openAIClient = new AzureOpenAIClient(new Uri(endpoint), new DefaultAzureCredential()); 
//AzureOpenAIClient openAIClient = new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));

// This must match the custom deployment name you chose for your model
ImageClient chatClient = openAIClient.GetImageClient("my-image-gen-test");

var imageGeneration = await chatClient.GenerateImageAsync(
        "a happy monkey sitting in a tree, in watercolor",
        new ImageGenerationOptions()
        {
            Size = GeneratedImageSize.W1024xH1024
        }
    );

Console.WriteLine(imageGeneration.Value.ImageUri);