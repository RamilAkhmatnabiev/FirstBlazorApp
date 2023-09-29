using FirstBlazorApp.Data.Models;

namespace FirstBlazorApp.Data.Services.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorRecord> GetAuthorRecords();
        AuthorRecord GetAuthor(int id);
        void SaveAuthor(AuthorRecord author);
    }
}
