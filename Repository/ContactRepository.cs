using ContactControl.Data;
using ContactControl.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactControl.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ContactRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Contact ListId(int id)
        {
            return _databaseContext.Contacts.FirstOrDefault(x => x.Id == id );
        }

        public List<Contact> ListAll()
        {
            return _databaseContext.Contacts.ToList();
        }

        public Contact Create(Contact contact)
        {
            _databaseContext.Contacts.Add(contact);
            _databaseContext.SaveChanges();
            return contact;
        }

        public Contact Edit(Contact contact)
        {
            Contact contactDB = ListId(contact.Id);

            if (contactDB == null) throw new System.Exception("Ops!! There was an error updating this contact");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Telephone = contact.Telephone;

            _databaseContext.Contacts.Update(contactDB);
            _databaseContext.SaveChanges();

            return contactDB;
        }

        public bool Delete(int id)
        {
            Contact contactDB = ListId(id);

            if (contactDB == null) throw new System.Exception("Ops!! There was an error deleting this contact");

            _databaseContext.Contacts.Remove(contactDB);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
