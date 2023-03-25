using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;

namespace StrategyPattern.Services.Export
{
    public class ExportService : IExportService
    {
        private readonly Dictionary<string, IExporter> _exporters = new();        

        public ExportService(IEnumerable<IExporter> exporters)
        {
            foreach (var exporter in exporters)
            {
                _exporters.Add(exporter.FileExtension, exporter);
            }
        }

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
