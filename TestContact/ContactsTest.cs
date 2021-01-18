using AutoMapper;
using Contacts.Configuration;
using Contacts.Controllers;
using Contacts.Interface;
using Contacts.Models;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace TestContact
{
    public class ContactsTest
    {
        private static IMapper _mapper;

        public ContactsTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }


        [Fact]
        public async Task GetContact_AndReturnResponseDataOk()
        {
            var mockRepo = new Mock<IContactData>();
            mockRepo.Setup(repo => repo.allContacts())
                .ReturnsAsync(GetTestSessions());

            var controller = new ContactsController(mockRepo.Object, _mapper);


            ResponseData r = new ResponseData
            {
                statusCode = 200,
                message = "ok",
                data = JsonConvert.SerializeObject(GetTestSessions())
            };
            var result = await controller.GetContact(1, 5, "Cualquiera");

            //var viewResult = Assert.IsType<ResponseData>(result);
            //var model = Assert.IsAssignableFrom<ResponseData>(viewResult.ViewData.Model);
            Assert.IsNotNull(result);
            Assert.AreEqual(r, result);
        }

        [Fact]
        public async Task GetContact_AndReturnException()
        {
            var mockRepo = new Mock<IContactData>();
            mockRepo.Setup(repo => repo.allContacts())
                .ReturnsAsync(GetTestSessions());

            var controller = new ContactsController(mockRepo.Object, _mapper);


            ResponseData r = new ResponseData
            {
                statusCode = 200,
                message = "ok",
                data = JsonConvert.SerializeObject(GetTestSessions())
            };

            try
            {
                var result = await controller.GetContact(1, 5, "Cualquiera");
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }

        private List<Contact> GetTestSessions()
        {
            var sessions = new List<Contact>();
            sessions.Add(new Contact()
            {
                FirstName = "Ruben",
                LastName = "Daboin",
                Company = "Taco",
                Email = "rd@gmail.com",
                PhoneNumber = 1178369842
            });

            sessions.Add(new Contact()
            {
                FirstName = "Pedro",
                LastName = "PErez",
                Company = "Cualquiera",
                Email = "pp@gmail.com",
                PhoneNumber = 1178369843
            });
            return sessions;
        }
    }
}
