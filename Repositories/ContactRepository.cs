using ContactManangement.Data;
using ContactManangement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManangement.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DBContext _dbContext;
        public ContactRepository(DBContext dbContext)
        {
            _dbContext = dbContext;  
        }
        public async Task<List<Contact>> GetContactListAsync()
        {
            var contacts = await _dbContext.Contacts.AsNoTracking().ToListAsync();
            return contacts;
        }
        public async Task<Contact> GetContactByIdAsync(string contactId)
        {
            var contact = await _dbContext.Contacts.AsNoTracking().FirstOrDefaultAsync((contact) => contact.ContactId == contactId);
            return contact ?? await Task.FromResult<Contact>(null);
        }
        public async Task<int> AddContactAsync(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            return await _dbContext.SaveChangesAsync(); ;
        }
        public async Task<int> UpdateContactAsync(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteContactAsync(Contact contact)
        {
            _dbContext.Contacts.Remove(contact);
            return await _dbContext.SaveChangesAsync();
        }



        
    }
}
