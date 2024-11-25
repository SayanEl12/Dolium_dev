using lib_entities;
using lib_applications.Interfaces;
using lib_repositories.Interfaces;
using lib_repositories;
using System.Linq.Expressions;

namespace lib_applications.Implementations;
public class LogsApp : ILogsApp
{
    private ILogsRepository iRespository;

    public LogsApp(ILogsRepository iRespository)
    {
        this.iRespository = iRespository;
    }

    public void Configure(string stringConnection)
    {
        this.iRespository!.Configure(stringConnection);
    }

    public List<Logs> GetList()
    {
        return this.iRespository!.GetList();
    }

    public Logs Save(Logs entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id != 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Save(entity);
    }

    public List<Logs> Search(Logs entity, string type)
    {
        Expression<Func<Logs, bool>>? conditions = null;
        switch (type.ToUpper())
        {
            case "USER": conditions = x => x.FrKey_User!.Equals(entity.FrKey_User); break;
            case "DESCRIPTION": conditions = x => x.Description!.Contains(entity.Description); break;
            case "DATE": conditions = x => x.Date!.Equals(entity.Date); break;
            default: conditions = x => x.Id == entity.Id; break;
        }

        return this.iRespository!.Search(conditions);
    }

    public Logs Modify(Logs entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id == 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Modify(entity);
    }

    public Logs Delete(Logs entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id == 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Delete(entity);
    }
    public List<Logs> DeleteUsers(int Id)
    {
        List<Logs> LogsDeleted = new List<Logs>();
        List<Logs> LogsToDelete = new List<Logs>();
        Logs LogToDel = new Logs();
        LogToDel.FrKey_User = Id;
        LogsToDelete = Search(LogToDel, "USER");

        foreach (var log in LogsToDelete)
        {
            log.FrKey_User = 1;
            var logDel = new Logs();
            logDel = Modify(log);
            LogsDeleted.Add(logDel);
        }
        
        return LogsDeleted;
    }
}