using Contacts.Context;
using Contacts.Interface;
using Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data
{
    public class ContactData : IContactData
    {
        private readonly AppDbContext _dbContext;
        public ContactData(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<List<Contact>> allContacts()
        {
            List<Contact> listContacts = new List<Contact>();
            try
            {
                using (var dbConnection = _dbContext.CreateConnection())
                {
                    String sql = "getAllContacts";

                    SqlCommand command = new SqlCommand(sql, dbConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {

                        while (reader.Read())
                        {
                            Contact c = new Contact();
                            c.FirstName = reader["FirstName"].ToString();
                            c.LastName = reader["LastName"].ToString();
                            c.Company = reader["Company"].ToString();
                            c.Email = reader["Email"].ToString();
                            //se puede usar el metodo GetInt32 con la posicion de la columna
                            c.PhoneNumber = reader["PhoneNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PhoneNumber"]);
                            listContacts.Add(c);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            return listContacts;
        }


        public async Task<ResponseData> addContact(ContactPost contact)
        {
            ResponseData res = new ResponseData();
            try
            {
                using (var dbConnection = _dbContext.CreateConnection())
                {
                    String sql = "addContacts";

                    
                    using (SqlCommand command = new SqlCommand(sql, dbConnection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                        command.Parameters.AddWithValue("@LastName", contact.LastName);
                        command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                        command.Parameters.AddWithValue("@Company", contact.Company);
                        command.Parameters.AddWithValue("@Email", contact.Email);
                        await command.ExecuteNonQueryAsync();
                    }

                }
                res.status = "ok";
                res.statusCode = 200;

            }
            catch (SqlException sqlEx)
            {
                res.status = "sqlError";
                res.statusCode = 500;
                res.message = sqlEx.Message;
            }

            catch (Exception ex)
            {
                res.status = "InternalServerError";
                res.statusCode = 500;
                res.message = ex.Message;
            }
            return res;
        }

        public async Task<ResponseData> editContact(ContactPost contact)
        {
            ResponseData res = new ResponseData();
            try
            {
                using (var dbConnection = _dbContext.CreateConnection())
                {
                    String sql = "editContacts";


                    using (SqlCommand command = new SqlCommand(sql, dbConnection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                        command.Parameters.AddWithValue("@LastName", contact.LastName);
                        command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                        command.Parameters.AddWithValue("@Company", contact.Company);
                        command.Parameters.AddWithValue("@Email", contact.Email);
                        await command.ExecuteNonQueryAsync();
                    }

                }
                res.status = "ok";
                res.statusCode = 200;

            }
            catch (SqlException sqlEx)
            {
                res.status = "sqlError";
                res.statusCode = 500;
                res.message = sqlEx.Message;
            }
            catch (Exception ex)
            {
                res.status = "InternalServerError";
                res.statusCode = 500;
                res.message = ex.Message;
            }
            return res;
        }

        public async Task<ResponseData> deleteContact(string FirstName, string LastName)
        {
            ResponseData res = new ResponseData();
            try
            {
                using (var dbConnection = _dbContext.CreateConnection())
                {
                    String sql = "deleteContacts";


                    using (SqlCommand command = new SqlCommand(sql, dbConnection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        await command.ExecuteNonQueryAsync();
                    }

                }
                res.status = "ok";
                res.statusCode = 200;

            }
            catch (SqlException sqlEx)
            {
                res.status = "sqlError";
                res.statusCode = 500;
                res.message = sqlEx.Message;
            }
            catch (Exception ex)
            {
                res.status = "InternalServerError";
                res.statusCode = 500;
                res.message = ex.Message;
            }
            return res;
        }
    }
}
