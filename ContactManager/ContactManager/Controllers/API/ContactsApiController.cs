using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ContactManager.Models;
using ContactManager.DTOs;
using AutoMapper;

namespace ContactManager.Controllers.API
{
    public class ContactsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
             

        // GET api/ContactsApi
        public IEnumerable<ContactDto> GetPersonContacts()
        {
            return db.PersonContacts.ToList().Select(Mapper.Map<PersonContactInfo, ContactDto>);
        }

        // GET api/ContactsApi/5
               
        public IHttpActionResult GetPersonContactInfo(int id)
        {
            PersonContactInfo personcontactinfo = db.PersonContacts.Find(id);
            if (personcontactinfo == null)
            {
               return NotFound();
            }


            return Ok(Mapper.Map<PersonContactInfo, ContactDto>(personcontactinfo));
        }

        

        // PUT api/ContactsApi/5
        [HttpPut]
        public IHttpActionResult UpdatePersonContactInfo(int id, ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id != contactDto.id)
            {
                return BadRequest();
            }
            var contactInDB = db.PersonContacts.Find(id);
            Mapper.Map(contactDto, contactInDB);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(contactDto);            
        }

        // POST api/ContactsApi
        [HttpPost]
        public IHttpActionResult CreatePersonContactInfo(ContactDto contactdto)
        {
            PersonContactInfo personContactInfo;
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            if (contactdto.id != 0)
            {
                personContactInfo = db.PersonContacts.Find(contactdto.id);
                Mapper.Map(contactdto, personContactInfo);
            }
            else
            {
                personContactInfo = Mapper.Map<ContactDto, PersonContactInfo>(contactdto);

                db.PersonContacts.Add(personContactInfo);
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInfoExists(personContactInfo.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            contactdto.id = personContactInfo.id;
            return Ok(contactdto);
        }

        // DELETE api/ContactsApi/5
        [HttpDelete]
        public IHttpActionResult DeletePersonContactInfo(int id)
        {
            PersonContactInfo personContactInfo = db.PersonContacts.Find(id);
            
            if (personContactInfo == null)
            {
                return NotFound();
            }
            db.PersonContacts.Remove(personContactInfo);
            db.SaveChanges();            

            return Ok(Mapper.Map<PersonContactInfo, ContactDto>(personContactInfo));
        }

        private bool ContactInfoExists(int id)
        {
            return db.PersonContacts.Count(e => e.id == id) > 0;
        }
    }
}