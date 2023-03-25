using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StrategyPattern.Models;
using StrategyPattern.Services;
using StrategyPattern.Services.Export;

namespace StrategyPattern.Pages
{
    public class ContactModel : PageModel
    {
        readonly IContactService _contactService;
        readonly IExportService _exportService;

        public ContactModel(IContactService contactService, IExportService exportService)
        {
            _contactService = contactService;
            _exportService = exportService;
        }

        public void OnGet() => Contacts = _contactService.GetContacts();

        public FileResult OnGetDownloadFile(string fileType)
        {
            return _exportService.Export(fileType, _contactService.GetContacts());
        }

        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
