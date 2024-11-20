using lib_entities;

namespace lib_presentations.Interfaces;
public interface IUsersPresentation
{
    Task<List<Users>> GetList();
    Task<List<Users>> Search(Users entity, string type);
    Task<Users> Save(Users entity);
    Task<Users> Modify(Users entity);
    Task<Users> Delete(Users entity);
}