using lib_entities;
using lib_repositories.Interfaces;

namespace lib_repositories.Implementations;
public class ImagesRepository : IImagesRepository
{
    private Connection? _connection;

    public ImagesRepository(Connection connection)
    {
        this._connection = connection;
    }

    public void Configure(string stringConnection)
    {
        this._connection!.StringConnection = stringConnection;
    }

    public List<Images> GetList()
    {
        return this._connection!.GetList<Images>();
    }

    public Images Save(Images entity)
    {
        _connection!.Save(entity);
        _connection!.Commit();
        return entity;
    }

    public Images Modify(Images entity)
    {
        _connection!.Modify(entity);
        _connection!.Commit();
        return entity;
    }

    public Images Delete(Images entity)
    {
        _connection!.Delete(entity);
        _connection!.Commit();
        return entity ;
    }
}