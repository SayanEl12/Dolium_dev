using lib_entities;
using lib_repositories.Interfaces;
using System.Linq.Expressions;

namespace lib_repositories.Implementations;
public class UsersRepository : IUsersRepository
{
    private Connection? _connection;

    public UsersRepository(Connection connection)
    {
        this._connection = connection;
    }

    public void Configure(string stringConnection)
    {
        this._connection!.StringConnection = stringConnection;
    }

    public List<Users> GetList()
    {
        return this._connection!.GetList<Users>();
    }

    public Users Save(Users entity)
    {
        _connection!.Save(entity);
        _connection!.Commit();
        return entity;
    }

    public List<Users> Search(Expression<Func<Users, bool>> conditions)
    {
        return _connection!.Search(conditions);
    }

    public Users Modify(Users entity)
    {
        _connection!.Modify(entity);
        _connection!.Commit();
        return entity;
    }

    public Users Delete(Users entity)
    {
        _connection!.Delete(entity);
        _connection!.Commit();
        return entity;
    }
}