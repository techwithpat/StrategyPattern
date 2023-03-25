using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;

namespace StrategyPattern.Services
{
    public interface IExporter
    {
        FileResult Export(List<Contact> contacts);
    }
}
