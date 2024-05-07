using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp2.Shared;


namespace BlazorApp2.Client.Data
{
   
        public class ContactService : IContactService
        {
            private List<Contact> _contacts;

            public ContactService()
            {
                _contacts = new List<Contact>
            {
                new Contact { Id = 1, FirstName = "Heba", LastName = "Alahmad", Email = "heba@yahoo.com", PhoneNumber = "0780098539" },
                new Contact { Id = 2, FirstName = "Saja", LastName = "Ahmad", Email = "saja@yahoo.com", PhoneNumber = "0780098598" }
            };
            }

            public Task<List<Contact>> GetContactsAsync()
            {
                return Task.FromResult(_contacts);
            }

            public Task<Contact> GetContactByIdAsync(int id)
            {
                var contact = _contacts.FirstOrDefault(c => c.Id == id);
                return Task.FromResult(contact);
            }

            public Task AddContactAsync(Contact contact)
            {
                if (contact == null)
                    throw new ArgumentNullException(nameof(contact));

                contact.Id = _contacts.Count > 0 ? _contacts.Max(c => c.Id) + 1 : 1;
                _contacts.Add(contact);
                return Task.CompletedTask;
            }

            public Task UpdateContactAsync(Contact contact)
            {
                if (contact == null)
                    throw new ArgumentNullException(nameof(contact));

                var existingContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
                if (existingContact != null)
                {
                    existingContact.FirstName = contact.FirstName;
                    existingContact.LastName = contact.LastName;
                    existingContact.Email = contact.Email;
                    existingContact.PhoneNumber = contact.PhoneNumber;
                }
                return Task.CompletedTask;
            }

            public Task DeleteContactAsync(int id)
            {
                var contact = _contacts.FirstOrDefault(c => c.Id == id);
                if (contact != null)
                    _contacts.Remove(contact);
                return Task.CompletedTask;
            }
        }
    }




