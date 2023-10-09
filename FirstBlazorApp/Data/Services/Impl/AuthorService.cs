using FirstBlazorApp.Data.Models;
using FirstBlazorApp.Data.Services.Interfaces;
using MatBlazor;

namespace FirstBlazorApp.Data.Services.Impl
{
    public class AuthorService : IAuthorService
    {
        private const string authorsServiceApiUrl = "https://localhost:7249/api/";
        private IBaseDumpSaver BaseDumpSaver { get; set; }
        private HttpClient HttpClient { get; set; }

        public AuthorService(IBaseDumpSaver baseDumpSaver, HttpClient httpClient)
        {
            this.BaseDumpSaver = baseDumpSaver;
            this.HttpClient = httpClient;
        }

        public async Task<AuthorRecord?> GetAuthor(int authorId)
        {
            return await this.HttpClient.GetFromJsonAsync<AuthorRecord>($"{authorsServiceApiUrl}Authors/{authorId}");
        }

        public async Task<List<AuthorRecord>> GetAuthorRecords()
        {
            return await this.HttpClient.GetJsonAsync<List<AuthorRecord>>($"{authorsServiceApiUrl}Authors");
        }

        public async Task<HttpResponseMessage> SaveAuthor(AuthorRecord author)
        {
            var response = await this.HttpClient.PostAsJsonAsync($"{authorsServiceApiUrl}Authors", author);
            AuthorRecord? createdAuthor = await response.Content.ReadFromJsonAsync<AuthorRecord>();

            return response;
        }

        public async Task<HttpResponseMessage> UpdateAuthor(AuthorRecord author)
        {
            try
            {
                return await this.HttpClient.PutAsJsonAsync($"{authorsServiceApiUrl}Authors/{author.AuthorId}", author);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> DeleteAuthor(int authorId)
        {
            return await this.HttpClient.DeleteAsync($"{authorsServiceApiUrl}Authors/{authorId}");
        }
    }
}