using ContactControl.Models;
using System.Collections.Generic;

namespace ContactControl.Repository
{
    public interface IContactRepository
    {
        Contact ListId(int id);
        List<Contact> ListAll();
        Contact Create(Contact contact);
        Contact Edit(Contact contact);
        bool Delete(int id);
    }
}
