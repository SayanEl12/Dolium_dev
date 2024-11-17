using lib_entities;
namespace lib_repositories.Interfaces;

public interface IUsersRepository
{
    void Configure(string stringConnection);
    List<Users> GetList();
    Users Save(Users entity);
    Users Modify(Users entity);
    Users Delete(Users entity);
}