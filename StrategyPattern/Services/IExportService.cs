using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;

namespace StrategyPattern.Services
{
    public interface IExportService
    {
        FileResult Export(string fileType, List<Contact> contacts);
        FileResult ExportToCsv(List<Contact> contacts);
        FileResult ExportToJson(List<Contact> contacts);
        FileResult ExportToXml(List<Contact> contacts);
    }
}