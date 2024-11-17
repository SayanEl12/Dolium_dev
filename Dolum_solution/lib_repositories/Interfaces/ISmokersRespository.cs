using lib_entities;

namespace lib_repositories.Interfaces;
public interface ISmokersRespository
{
    void Configure(string stringConnection);
    List<Smokers> GetList();
    Smokers Save(Smokers entity);
    Smokers Modify(Smokers entity);
    Smokers Delete(Smokers entity);
}