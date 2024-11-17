using lib_entities;
using System.Linq.Expressions;

namespace lib_repositories.Interfaces;
public interface IQualitiesRepository
{
    void Configure(string stringConnection);
    List<Qualities> GetList();
    Qualities Save(Qualities entity);
    List<Qualities> Search(Expression<Func<Qualities, bool>> conditions);
    Qualities Modify(Qualities entity);
    Qualities Delete(Qualities entity);
}