using lib_entities;
namespace lib_applications.Interfaces;
public interface IUsersApp
{
    void Configure(string stringConnection);
    List<Users> GetList();
    Users Save(Users entity);
    List<Users> Search(Users entity, string type);
    Users Modify(Users entity);
    Users Delete(Users entity);
    
}