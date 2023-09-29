using FirstBlazorApp.Data.Services.Interfaces;

namespace FirstBlazorApp.Data.Services.Impl;

public class BaseDumpSaver: IBaseDumpSaver
{
    public void SaveEntity<TEntity>(TEntity entity, ICollection<TEntity> baseCollection) where TEntity : BaseRecord
    {
        var biggestId = baseCollection
            .Max(x => x.Id);
        
        entity.Id = ++biggestId;
        
        baseCollection.Add(entity);
    }
}