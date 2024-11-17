using lib_entities;

namespace lib_repositories.Interfaces;
public interface ILogsRepository
{
    void Configure(string stringConnection);
    List<Logs> GetList();
    Logs Save(Logs entity);
    Logs Modify(Logs entity);
    Logs Delete(Logs entity);
}