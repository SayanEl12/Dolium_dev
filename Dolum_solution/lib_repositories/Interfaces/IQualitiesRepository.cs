using lib_entities;

namespace lib_repositories.Interfaces;
public interface IQualitiesRepository
{
    void Configure(string stringConnection);
    List<Qualities> GetList();
    Qualities Save(Qualities entity);
    Qualities Modify(Qualities entity);
    Qualities Delete(Qualities entity);
}