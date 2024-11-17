using lib_entities;
using lib_repositories.Interfaces;
using System.Linq.Expressions;

namespace lib_repositories.Implementations;
public class SalesRepository: ISalesRepository
{
    private Connection? _connection;

    public SalesRepository(Connection connection)
    {
        this._connection = connection;
    }

    public void Configure(string stringConnection)
    {
        this._connection!.StringConnection = stringConnection;
    }

    public List<Sales> GetList()
    {
        return this._connection!.GetList<Sales>();
    }

    public Sales Save(Sales entity)
    {
        _connection!.Save(entity);
        _connection!.Commit();
        return entity;
    }
    public List<Sales> Search(Expression<Func<Sales, bool>> conditions)
    {
        return _connection!.Search(conditions);
    }

    public Sales Modify(Sales entity)
    {
        _connection!.Modify(entity);
        _connection!.Commit();
        return entity;
    }

    public Sales Delete(Sales entity)
    {
        _connection!.Delete(entity);
        _connection!.Commit();
        return entity;
    }
}