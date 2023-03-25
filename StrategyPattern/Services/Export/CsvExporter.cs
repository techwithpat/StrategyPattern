using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;
using System.Text;

namespace StrategyPattern.Services.Export
{
    public class CsvExporter : IExporter
    {
        public string FileExtension => "csv";

        public FileResult Export(List<Contact> contacts)
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
    }
}
