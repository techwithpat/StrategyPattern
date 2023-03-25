using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;

namespace StrategyPattern.Services.Export
{
    public interface IExporter
    {
        FileResult Export(List<Contact> contacts);
        string FileExtension { get; }
    }
}
