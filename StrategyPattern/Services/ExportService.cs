using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;

namespace StrategyPattern.Services
{
    public class ExportService : IExportService
    {
        private readonly Dictionary<string, IExporter> _exporters = new()
        {
            { "csv", new CsvExporter() },
            { "json", new JsonExporter() },
            { "xml", new XmlExporter() }
        };

        public FileResult Export(string fileType, List<Contact> contacts)
        {
            if (!_exporters.TryGetValue(fileType, out var exporter))
            {
                throw new ArgumentException($"{fileType} not supported");
            }

            return exporter.Export(contacts);
        }
    }
}
