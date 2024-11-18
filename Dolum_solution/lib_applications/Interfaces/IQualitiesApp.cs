using lib_entities;
using System.Linq.Expressions;
namespace lib_repositories.Interfaces;

public interface IQualitiesApp
{
    void Configure(string stringConnection);
    List<Qualities> GetList();
    Qualities Save(Qualities entity);
    List<Qualities> Search(Qualities entity,string type);
    Qualities Modify(Qualities  entity);
    Qualities Delete(Qualities  entity);
}
