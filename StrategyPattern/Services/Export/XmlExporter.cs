using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;
using System.Xml.Serialization;

namespace StrategyPattern.Services.Export
{
    public class XmlExporter : IExporter
    {
        public string FileExtension => "xml";

        public FileResult Export(List<Contact> contacts)
        {
            MemoryStream stream = new();

            XmlSerializer serializer = new(typeof(List<Contact>));

            serializer.Serialize(stream, contacts);

            stream.Position = 0;

            return new FileContentResult(stream.ToArray(), "text/plain");
        }
    }
}
