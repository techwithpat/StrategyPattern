using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;
using System.Text.Json;
using System.Text;

namespace StrategyPattern.Services.Export
{
    public class JsonExporter : IExporter
    {
        public string FileExtension => "json";

        public FileResult Export(List<Contact> contacts)
        {
            string json = JsonSerializer.Serialize(contacts);

            byte[] bytes = Encoding.UTF8.GetBytes(json);

            return new FileContentResult(bytes, "text/plain");
        }
    }
}
