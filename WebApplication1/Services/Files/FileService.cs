using sun.swing;
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services.Files
{
    public class FileService :FileInterface
    {
        public async Task UploadFile(string FilePath)
        {
            var client = new HttpClient();
            var form = new MultipartFormDataContent();
            var fileStream = File.OpenRead(FilePath);
            var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            form.Add(streamContent, "file", Path.GetFileName(FilePath));

            var response = await client.PostAsync("https://localhost:7144/api/file", form);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("File upload failed: " + response.ReasonPhrase);
            }
            else
            {
                Console.WriteLine("File uploaded successfully.");
            }
        }
    }
}
