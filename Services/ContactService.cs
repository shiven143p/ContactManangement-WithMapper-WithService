using AutoMapper;
using ContactManangement.Entities;
using ContactManangement.Entities.Dto;
using ContactManangement.Middleware;
using ContactManangement.Repositories;

namespace ContactManangement.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly InternalResponse _internalResponse;
        private IMapper _mapper;
        public ContactService(IContactRepository contactRepository, InternalResponse internalResponse, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _internalResponse = internalResponse;
            _mapper = mapper;
        }

        public async Task<InternalResponse> GetContactListAsync()
        {
            List<Contact> contacts = await _contactRepository.GetContactListAsync();
            _internalResponse.Result = _mapper.Map<List<ContactDto>>(contacts);
            return _internalResponse;
        }

        public async Task<InternalResponse> GetContactByIDAsync(string contactId)
        {
            Contact contact = await _contactRepository.GetContactByIdAsync(contactId);
            _internalResponse.Result = _mapper.Map<ContactDto>(contact);
            if (_internalResponse.Result is null)
            {
                _internalResponse.IsSuccess = false;
                _internalResponse.Message = "No Contact Found";
            }
            return _internalResponse;
            
        }

        public async Task<InternalResponse> AddContactAsync(ContactDto contactDto)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);

            //Contact contact = new Contact
            //{
            //    ContactId = string.IsNullOrEmpty(contactDto.ContactId) ? Guid.NewGuid().ToString(): contactDto.ContactId,
            //    ContactName = contactDto.ContactName,
            //    ContactPhone = contactDto.ContactPhone,
            //    ContactEmail = contactDto.ContactEmail,
            //    ContactAddress = contactDto.ContactAddress
            //};

            _internalResponse.Result = await _contactRepository.AddContactAsync(contact) > 0 ? "Contact Added Successfully" : "";
            return _internalResponse;
        }

        public async Task<InternalResponse> UpdateContactAsync(ContactDto contactDto)
        {
            //Contact contact = new()
            //{
            //    ContactId = contactDto.ContactId,
            //    ContactName = contactDto.ContactName,
            //    ContactPhone = contactDto.ContactPhone,
            //    ContactEmail = contactDto.ContactEmail,
            //    ContactAddress = contactDto.ContactAddress,
            //};
         
            Contact contact = _mapper.Map<Contact>(contactDto);
            _internalResponse.Result = await _contactRepository.UpdateContactAsync(contact) > 0 ? "Contact Updated Successfully" : ""; ;
            return _internalResponse;
        }
        
        public async Task<InternalResponse> DeleteContactAsync(string contactId)
        {
            Contact contact = await _contactRepository.GetContactByIdAsync(contactId);
            if (contact is null)
            {
                _internalResponse.IsSuccess = false;
                _internalResponse.Message = "No Contact Found";
                return _internalResponse;
            }

            _internalResponse.Result = await _contactRepository.DeleteContactAsync(contact) > 0 ? "Contact Deleted Successfully" : ""; ;
            return _internalResponse;
        }

    }
}
