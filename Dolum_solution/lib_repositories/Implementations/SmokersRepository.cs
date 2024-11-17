using lib_entities;
using lib_repositories.Interfaces;
using System.Linq.Expressions;

namespace lib_repositories.Implementations;
public class SmokersRepository : ISmokersRespository
{
    private Connection? _connection;

    public SmokersRepository(Connection connection)
    {
        this._connection = connection;
    }

    public void Configure(string stringConnection)
    {
        this._connection!.StringConnection = stringConnection;
    }

    public List<Smokers> GetList()
    {
        return this._connection!.GetList<Smokers>();
    }

    public Smokers Save(Smokers entity)
    {
        _connection!.Save(entity);
        _connection!.Commit();
        return entity;
    }

    public List<Smokers> Search(Expression<Func<Smokers,bool>> conditions)
    {
        return _connection!.Search(conditions);
    }
    

    public Smokers Modify(Smokers entity)
    {
        _connection!.Modify(entity);
        _connection!.Commit();
        return entity;
    }

    public Smokers Delete(Smokers entity)
    {
        _connection!.Delete(entity);
        _connection!.Commit();
        return entity;
    }
}