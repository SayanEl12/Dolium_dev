using lib_entities;
using System.Linq.Expressions;

namespace lib_repositories.Interfaces;
public interface ILogsRepository
{
    void Configure(string stringConnection);
    List<Logs> GetList();
    Logs Save(Logs entity);
    List<Logs> Search(Expression<Func<Logs, bool>> conditions);
    Logs Modify(Logs entity);
    Logs Delete(Logs entity);
}