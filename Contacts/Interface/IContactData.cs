using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Interface
{
    public interface IContactData
    {
        public Task<List<Contact>> allContacts();
        public Task<ResponseData> addContact(ContactPost contact);
        public Task<ResponseData> editContact(ContactPost contact);
        public Task<ResponseData> deleteContact(string FirstName, string LastName);
    }
}
