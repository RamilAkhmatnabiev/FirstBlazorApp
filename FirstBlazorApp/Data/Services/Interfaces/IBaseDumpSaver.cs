namespace FirstBlazorApp.Data.Services.Interfaces;

public interface IBaseDumpSaver
{
    void SaveEntity<TEntity>(TEntity entity, ICollection<TEntity> baseCollection)
        where TEntity : BaseRecord;
}