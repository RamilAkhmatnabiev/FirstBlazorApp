using FirstBlazorApp.Data.Models;

namespace FirstBlazorApp.Data.Services.Interfaces;

public interface IPublishersPageService
{
    void SavePublisher(PublisherRecord publisher);
    List<PublisherRecord> GetPublishers();
}