using lib_entities;
using lib_repositories.Interfaces;
using System.Linq.Expressions;

namespace lib_repositories.Implementations;
public class LogsRepository : ILogsRepository
{
    private Connection? _connection;

    public LogsRepository(Connection connection)
    {
        this._connection = connection;
    }

    public void Configure(string stringConnection)
    {
        this._connection!.StringConnection = stringConnection;
    }

    public List<Logs> GetList()
    {
        return this._connection!.GetList<Logs>();
    }

    public Logs Save(Logs entity)
    {
        _connection!.Save(entity);
        _connection!.Commit();
        return entity;
    }
    public List<Logs> Search(Expression<Func<Logs, bool>> conditions)
    {
        return _connection!.Search(conditions);
    }
    public Logs Modify(Logs entity)
    {
        _connection!.Modify(entity);
        _connection!.Commit();
        return entity;
    }

    public Logs Delete(Logs entity)
    {
        _connection!.Delete(entity);
        _connection!.Commit();
        return entity;
    }
}