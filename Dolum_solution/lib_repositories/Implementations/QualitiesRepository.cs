using lib_entities;
using lib_repositories.Interfaces;

namespace lib_repositories.Implementations;
public class QualitiesRepository
{
    private Connection? _connection;

    public QualitiesRepository(Connection connection)
    {
        this._connection = connection;
    }

    public void Configure(string stringConnection)
    {
        this._connection!.StringConnection = stringConnection;
    }

    public List<Qualities> GetList()
    {
        return this._connection!.GetList<Qualities>();
    }

    public Qualities Save(Qualities entity)
    {
        _connection!.Save(entity);
        _connection!.Commit();
        return entity;
    }

    public Qualities Modify(Qualities entity)
    {
        _connection!.Modify(entity);
        _connection!.Commit();
        return entity;
    }

    public Qualities Delete(Qualities entity)
    {
        _connection!.Delete(entity);
        _connection!.Commit();
        return entity;
    }
}