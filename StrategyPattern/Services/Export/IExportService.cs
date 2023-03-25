using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;

namespace StrategyPattern.Services.Export
{
    public interface IExportService
    {
        FileResult Export(string fileType, List<Contact> contacts);
    }
}