using lib_entities;
using System.Linq.Expressions;
namespace lib_repositories.Interfaces;

public interface IUsersRepository
{
    void Configure(string stringConnection);
    List<Users> GetList();
    Users Save(Users entity);
    List<Users> Search(Expression<Func<Users, bool>> conditions);
    Users Modify(Users entity);
    Users Delete(Users entity);
}