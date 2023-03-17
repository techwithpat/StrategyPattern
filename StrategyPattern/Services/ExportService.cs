using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;
using System.IO;
using System.Net.Security;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using Document = iTextSharp.text.Document;

namespace StrategyPattern.Services
{
    public class ExportService : IExportService
    {
        public FileResult Export(string fileType, List<Contact> contacts)
        {
            return fileType switch
            {
                "csv" => ExportToCsv(contacts),
                "json" => ExportToJson(contacts),
                _ => ExportToXml(contacts)
            };
        }

        public FileResult ExportToCsv(List<Contact> contacts)
        {
            MemoryStream stream = new();
            StreamWriter writer = new(stream, Encoding.UTF8);

            writer.WriteLine("Name,Email,Phone");

            foreach (Contact contact in contacts)
            {
                writer.WriteLine($"{contact.Name},{contact.Email},{contact.Phone}");
            }

            writer.Flush();
            stream.Position = 0;

            return new FileStreamResult(stream, "text/csv");
        }

        public FileResult ExportToJson(List<Contact> contacts)
        {
            string json = JsonSerializer.Serialize(contacts);

            byte[] bytes = Encoding.UTF8.GetBytes(json);

            return new FileContentResult(bytes, "text/plain");
        }

        public FileResult ExportToXml(List<Contact> contacts)
        {
            MemoryStream stream = new();

            XmlSerializer serializer = new(typeof(List<Contact>));

            serializer.Serialize(stream, contacts);

            stream.Position = 0;

            return new FileContentResult(stream.ToArray(), "text/plain");
        }
    }
}
