using lib_entities;
using System.Linq.Expressions;

namespace lib_repositories.Interfaces;
public interface ISmokersRespository
{
    void Configure(string stringConnection);
    List<Smokers> GetList();
    Smokers Save(Smokers entity);
    List<Smokers> Search(Expression<Func<Smokers, bool>> conditions);

    Smokers Modify(Smokers entity);
    Smokers Delete(Smokers entity);
}