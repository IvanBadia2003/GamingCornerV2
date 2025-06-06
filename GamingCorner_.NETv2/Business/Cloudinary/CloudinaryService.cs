using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace GamingCorner.Business
{
    public class CloudinaryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _cloudName;
        private readonly string _uploadPreset;

        public CloudinaryService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _cloudName = "dsaptfjxa";
            _uploadPreset = "gamingcorner_unsigned"; // Corregido: sin asteriscos y guión bajo
        }

        public async Task<string> UploadImageRawAsync(IFormFile file)
        {
            using var client = new HttpClient();
            using var content = new MultipartFormDataContent();

            // Solo lo esencial
            content.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
            content.Add(new StringContent("gamingcorner_unsigned"), "upload_preset");

            var response = await client.PostAsync(
                "https://api.cloudinary.com/v1_1/dsaptfjxa/image/upload",
                content);

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response: {responseString}"); // Para debug

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {responseString}");

            var json = JsonSerializer.Deserialize<JsonElement>(responseString);
            return json.GetProperty("secure_url").GetString()!;
        }
    }

}
