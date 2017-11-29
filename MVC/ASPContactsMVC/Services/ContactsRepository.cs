using ASPContactsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASPContactsMVC.Services
{
    public class ContactsRepository:IContactRepository
    {
        private List<Contact> contacts = new List<Contact>()
        {
            new Contact { ID = 1, Prename = "Pipi", Surname ="Langstrumpf", Email="pipi.langstrumpf@kunterbunt.net" },
            new Contact { ID = 2, Prename = "Marina", Surname ="Ruiz", Email="marina.ruiz@sample.ru"}
        };

        /// <summary>
        /// returns all contacts in an array
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> GetAll()
        {
            return contacts.ToArray();
        }

        /// <summary>
        /// returns the contact given by the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact GetById(int id)
        {
            return contacts.FirstOrDefault(c => c.ID == id);
        }

        /// <summary>
        /// Removes contact from List
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            contacts.Remove(contacts.First(c => c.ID == id));
        }

        /// <summary>
        /// creates a contact
        /// </summary>
        /// <param name="contact"></param>
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
        
        /// <summary>
        /// returns all contacts with the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<Contact> GetContactsByName(string name)
        {
            List<Contact> sol = new List<Contact>();

            foreach(var item in this.contacts)
            {
                // might be surname or prename which is searched
                if (item.Prename.ToLower().Contains(name.ToLower()) || item.Surname.ToLower().Contains(name.ToLower()))
                {
                    sol.Add(item);
                }
            }
            return sol.ToArray();
        }
    }
}
