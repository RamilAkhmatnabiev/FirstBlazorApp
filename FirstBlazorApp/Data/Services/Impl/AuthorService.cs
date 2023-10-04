using FirstBlazorApp.Data.Models;
using FirstBlazorApp.Data.Services.Interfaces;
using MatBlazor;

namespace FirstBlazorApp.Data.Services.Impl
{
    public class AuthorService : IAuthorService
    {
        private const string authorsServiceApiUrl = "https://localhost:44317/api/";
        private IBaseDumpSaver BaseDumpSaver { get; set; }
        private HttpClient HttpClient { get; set; }

        public AuthorService(IBaseDumpSaver baseDumpSaver, HttpClient httpClient)
        {
            this.BaseDumpSaver = baseDumpSaver;
            this.HttpClient = httpClient;
        }

        private List<AuthorRecord> _authors = new List<AuthorRecord>()
        {
            new AuthorRecord()
            {
                AuthorId = 1, FirstName = "Author 1", LastName = "AuthorLastName 1", Address = "SomeAddress1",
                Description = "Descroption1", City = "City1", EmailAddress = "SomeEMail1@email.com", Salary = 10000
            },
            new AuthorRecord()
            {
                AuthorId = 2, FirstName = "Author 2", LastName = "AuthorLastName 2", Address = "SomeAddress2",
                Description = "Descroption2", City = "City2", EmailAddress = "SomeEMail2@email.com", Salary = 20000
            },
            new AuthorRecord()
            {
                AuthorId = 3, FirstName = "Author 3", LastName = "AuthorLastName 3", Address = "SomeAddress3",
                Description = "Descroption3", City = "City3", EmailAddress = "SomeEMail3@email.com", Salary = 30000
            },
            new AuthorRecord()
            {
                AuthorId = 4, FirstName = "Author 4", LastName = "AuthorLastName 4", Address = "SomeAddress4",
                Description = "Descroption4", City = "City4", EmailAddress = "SomeEMail4@email.com", Salary = 40000
            },
            new AuthorRecord()
            {
                AuthorId = 5, FirstName = "Author 5", LastName = "AuthorLastName 5", Address = "SomeAddress5",
                Description = "Descroption5", City = "City5", EmailAddress = "SomeEMail5@email.com", Salary = 50000
            }
        };

        public async Task<AuthorRecord?> GetAuthor(int authorId)
        {
            return await this.HttpClient.GetFromJsonAsync<AuthorRecord>($"{authorsServiceApiUrl}Authors/{authorId}");
        }

        public async Task<List<AuthorRecord>> GetAuthorRecords()
        {
            //return this._authors;
            return await this.HttpClient.GetJsonAsync<List<AuthorRecord>>($"{authorsServiceApiUrl}Authors");
        }

        public async Task<HttpResponseMessage> SaveAuthor(AuthorRecord author)
        {
            var response = await this.HttpClient.PostAsJsonAsync($"{authorsServiceApiUrl}Authors", author);
            AuthorRecord? createdAuthor = await response.Content.ReadFromJsonAsync<AuthorRecord>();

            return response;
        }

        public async Task<HttpResponseMessage> DeleteAuthor(int authorId)
        {
            return await this.HttpClient.DeleteAsync($"{authorsServiceApiUrl}Authors/{authorId}");
        }
    }
}