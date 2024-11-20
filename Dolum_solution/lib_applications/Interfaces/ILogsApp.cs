using lib_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ILogsApp
{
    void Configure(string stringConnection);
    List<Logs> GetList();
    Logs Save(Logs entity);
    List<Logs> Search(Logs entity, string type);
    Logs Modify(Logs entity);
    Logs Delete(Logs entity);
    public List<Logs> DeleteUsers(int Id);
}