using ASPContactsMVC.Models;
using System.Collections.Generic;

namespace ASPContactsMVC.Services
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        Contact GetById(int id);
        void Delete(int id);
        void AddContact(Contact contact);
        IEnumerable<Contact> GetContactsByName(string name);
    }
}
