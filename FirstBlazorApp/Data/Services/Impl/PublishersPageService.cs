using FirstBlazorApp.Data.Models;
using FirstBlazorApp.Data.Services.Interfaces;

namespace FirstBlazorApp.Data.Services.Impl;

public class PublishersPageService : IPublishersPageService
{
    private IBaseDumpSaver BaseDumpSaver;
    
    public PublishersPageService(IBaseDumpSaver baseDumpSaver)
    {
        this.BaseDumpSaver = baseDumpSaver;
    }
    private List<PublisherRecord> _publishers = new()
    {
        new PublisherRecord { Id = 1, Name = "PublisherName1", City = "Publisher1" },
        new PublisherRecord { Id = 2, Name = "PublisherName2", City = "Publisher2" },
        new PublisherRecord { Id = 3, Name = "PublisherName3", City = "Publisher3" },
        new PublisherRecord { Id = 4, Name = "PublisherName4", City = "Publisher4" },
    };
    
    public void SavePublisher(PublisherRecord publisher)
    {
        this.BaseDumpSaver.SaveEntity(publisher, this._publishers);
    }

    public List<PublisherRecord> GetPublishers()
    {
        return this._publishers;
    }
}