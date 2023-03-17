using StrategyPattern.Models;

namespace StrategyPattern.Services
{
    public interface IContactService
    {
        List<Contact> GetContacts();
    }
}