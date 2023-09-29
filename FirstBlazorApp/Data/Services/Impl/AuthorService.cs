using System.Diagnostics;
using FirstBlazorApp.Data.Models;
using FirstBlazorApp.Data.Services.Interfaces;

namespace FirstBlazorApp.Data.Services.Impl
{
    public class AuthorService : IAuthorService
    {
        private IBaseDumpSaver BaseDumpSaver;

        public AuthorService(IBaseDumpSaver baseDumpSaver)
        {
            this.BaseDumpSaver = baseDumpSaver;
        }
        private List<AuthorRecord> _authors = new List<AuthorRecord>()
            {
                new AuthorRecord() { Id = 1, Name = "Author 1",LastName = "AuthorLastName 1", Address = "SomeAddress1", Description = "Descroption1", City = "City1", Email = "SomeEMail1@email.com", Salary = 10000},
                new AuthorRecord() { Id = 2, Name = "Author 2",LastName = "AuthorLastName 2", Address = "SomeAddress2", Description = "Descroption2", City = "City2", Email = "SomeEMail2@email.com", Salary = 20000},
                new AuthorRecord() { Id = 3, Name = "Author 3",LastName = "AuthorLastName 3", Address = "SomeAddress3", Description = "Descroption3", City = "City3", Email = "SomeEMail3@email.com", Salary = 30000},
                new AuthorRecord() { Id = 4, Name = "Author 4",LastName = "AuthorLastName 4", Address = "SomeAddress4", Description = "Descroption4", City = "City4", Email = "SomeEMail4@email.com", Salary = 40000},
                new AuthorRecord() { Id = 5, Name = "Author 5",LastName = "AuthorLastName 5", Address = "SomeAddress5", Description = "Descroption5", City = "City5", Email = "SomeEMail5@email.com", Salary = 50000}
            };

        public AuthorRecord GetAuthor(int id)
        {
            return _authors
            .FirstOrDefault(x => x.Id == id);
        }

        public List<AuthorRecord> GetAuthorRecords()
        {
            return this._authors;
        }

        public void SaveAuthor(AuthorRecord author)
        {
            this.BaseDumpSaver.SaveEntity(author, this._authors);
        }
    }
}
