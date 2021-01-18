using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Contacts.Models
{
    public class Contact 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        
    }

    public class ContactDTO 
    {
        public ContactDTO()
        {
            contacts = new List<ContactResponse>();
        }
        public List<ContactResponse> contacts { get; set; }
    }

    public class ContactPost
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Company { get; set; }
        
        public string Email { get; set; }
        
        public int PhoneNumber { get; set; }
    }

    public class ContactResponse 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
    }



}
