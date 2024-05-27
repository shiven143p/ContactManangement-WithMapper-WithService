using ContactManangement.Entities.Dto;
using ContactManangement.Middleware;
using ContactManangement.Repositories;
using ContactManangement.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManangement.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactManagementController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactManagementController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("GetContacts")]
        public async Task<InternalResponse> Get()
        {
            //var contacts = await _contactRepository.GetContactListAsync();
            //return Ok(contacts);
            return await _contactService.GetContactListAsync();            
        }

        [HttpGet]
        [Route("GetContactById")]
        public async Task<InternalResponse> Get(string contactId)
        {
            //var contact = await _contactRepository.GetContactByIdAsync(contactId);
            //if (contact is null) return NotFound();

            //return Ok(contact);
            return await _contactService.GetContactByIDAsync(contactId);
        }

        [HttpPost]
        [Route("CreateContact")]
        public async Task<InternalResponse> Post(ContactDto contactDto)
        {
            //if (contactModel is null) return BadRequest();

            //Contact contact = new Contact
            //{
            //    ContactId = Guid.NewGuid().ToString(),
            //    ContactName = contactModel.ContactName,
            //    ContactPhone = contactModel.ContactPhone,
            //    ContactEmail = contactModel.ContactEmail,
            //    ContactAddress = contactModel.ContactAddress
            //};

            //var result = await _contactRepository.AddContactAsync(contact);
            //return Ok(result > 0 ? "Success" : "Failure");

            return await _contactService.AddContactAsync(contactDto);
        }

        [HttpPut]
        [Route("UpdateContact")]
        public async Task<InternalResponse> Put(ContactDto contactDto)
        {
            //Contact contact = await _contactRepository.GetContactByIdAsync(contactModel.ContactId);
            //if (contact is null) return NotFound();

            //contact.ContactId = contactModel.ContactId;
            //contact.ContactName = contactModel.ContactName;
            //contact.ContactPhone = contactModel.ContactPhone;
            //contact.ContactEmail = contactModel.ContactEmail;
            //contact.ContactAddress = contactModel.ContactAddress;

            //var result = await _contactRepository.UpdateContactAsync(contact);
            //return Ok(result > 0 ? "Success" : "Failure");
            return await _contactService.UpdateContactAsync(contactDto);
        }

        [HttpDelete]
        [Route("DeleteContact")]
        public async Task<InternalResponse> Delete(string contactId)
        {
            //Contact contact = await _contactRepository.GetContactByIdAsync(contactId);
            //if (contact is null) return NotFound();

            //var result = await _contactRepository.DeleteContactAsync(contact);
            //return Ok(result > 0 ? "Success" : "Failure");
            return await _contactService.DeleteContactAsync(contactId);

        }
    }
}
