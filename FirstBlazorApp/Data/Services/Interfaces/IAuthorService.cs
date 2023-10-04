using FirstBlazorApp.Data.Models;

namespace FirstBlazorApp.Data.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorRecord>> GetAuthorRecords();
        Task<AuthorRecord?> GetAuthor(int authorId);
        Task<HttpResponseMessage> SaveAuthor(AuthorRecord author);
        Task<HttpResponseMessage> DeleteAuthor(int authorId);
    }
}
