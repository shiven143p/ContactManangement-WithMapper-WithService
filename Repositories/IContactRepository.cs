using ContactManangement.Entities;

namespace ContactManangement.Repositories
{
    public interface IContactRepository
    {
        public Task<List<Contact>> GetContactListAsync();
        public Task<Contact> GetContactByIdAsync(string contactId); 
        public Task<int> AddContactAsync(Contact contact);
        public Task<int> UpdateContactAsync(Contact contact);
        public Task<int> DeleteContactAsync(Contact contact);

    }
}
