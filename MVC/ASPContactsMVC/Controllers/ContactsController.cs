using ASPContactsMVC.Models;
using ASPContactsMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPContactsMVC.Controllers
{
    public class ContactsController : Controller
    {
        private IContactRepository contactRepository;
        
        public ContactsController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        /// <summary>
        /// show all Contacts in the List
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(contactRepository.GetAll());
        }

        /// <summary>
        /// Show details from Contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var contactToFind = contactRepository.GetById(id);
            if(contactToFind == null)
            {
                return NotFound();
            }
            return View(contactToFind);
        }

        /// <summary>
        /// Show Contact which is about to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var contactToDelete = contactRepository.GetById(id);
            if(contactToDelete == null)
            {
                return NotFound();
            }
            return View(contactToDelete);
        }

        /// <summary>
        /// Delete a contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteConfirmed (int id)
        {
            contactRepository.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Is used to create a contact
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateContact(Contact contact)
        {
            contactRepository.AddContact(contact);
            return View("CreateContact");
        }

        /// <summary>
        /// Find a person by name - view
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ContactNameList(string name)
        {
            
            if(name == null)
            {
                return NotFound();
            }
            return View(contactRepository.GetContactsByName(name));
        }
    }
}