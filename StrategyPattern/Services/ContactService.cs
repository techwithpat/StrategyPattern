using StrategyPattern.Models;
using Faker;

namespace StrategyPattern.Services
{
    public class ContactService : IContactService
    {
        private List<Contact> _contacts;

        public ContactService()
        {
            _contacts = new List<Contact>();
        }

        public List<Contact> GetContacts()
        {
            for (int i = 0; i < 20; i++)
            {
                var contact = new Contact
                {
                    Id = i + 1,
                    Name = Name.FullName(),
                    Email = Internet.Email(),
                    Phone = Phone.Number(),
                    Address = Address.StreetAddress()
                };

                _contacts.Add(contact);
            }

            return _contacts;
        }
    }
}
