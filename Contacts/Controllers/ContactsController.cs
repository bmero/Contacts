using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Context;
using Microsoft.AspNetCore.Mvc;
using Contacts.Models;
using Contacts.Data;
using Contacts.Interface;
using AutoMapper;
using Newtonsoft.Json;
//using System.Text.Json;
//using Newtonsoft.Json.Linq;

namespace Contacts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactData data;
        private readonly IMapper mapper;

        public ContactsController(IContactData _contactData, IMapper _mapper)
        {
            data = _contactData;
            mapper = _mapper;
        }

        [HttpGet]
        [Route("GetContact")]
        public async Task<ActionResult> GetContact(int pageIndex, int pageSize, string company)
        {
            ResponseData res = new ResponseData();
            var list = await data.allContacts();
            List<ContactResponse> listResponse = new List<ContactResponse>();
            listResponse = mapper.Map<List<Contact>, List<ContactResponse>>(list);
            listResponse = listResponse.Skip(pageIndex * pageSize).Take(pageSize).Where(c => c.Company == company).ToList();
            res.data = JsonConvert.SerializeObject(listResponse);
            res.status = "ok";
            res.statusCode = 200;
            return Ok(res);
        }

        [HttpPut("{contact}")]
        public async Task<ActionResult<ResponseData>> EditContact(ContactPost contact)
        {
            var res = await data.editContact(contact);
            return Ok(res);
        }

        [HttpPost]
        [Route("DeleteContact")]
        public async Task<ActionResult> DeleteContact(string FirstName, string LastName)
        {

            var res = await data.deleteContact(FirstName, LastName);
            return Ok(res);
        }

        [HttpPost("{contact}")]
        public async Task<ActionResult> AddContact(ContactPost contact)
        {

            var res = await data.addContact(contact);
            return Ok(res);
        }


    }
}
