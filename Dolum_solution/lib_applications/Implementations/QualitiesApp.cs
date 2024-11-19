using lib_entities;
using lib_applications.Interfaces;
using lib_repositories.Interfaces;
using System.Linq.Expressions;

namespace lib_applications.Implementations;
public class QualitiesApp :IQualitiesApp
{
    private IQualitiesRepository iRespository;
    public QualitiesApp(IQualitiesRepository iRespository)
    {
        this.iRespository = iRespository;
    }
    
    public void Configure(string stringConnection)
    {
        this.iRespository!.Configure(stringConnection);
    }
    
    public List<Qualities> GetList()
    {
        return this.iRespository!.GetList();
    }
    public Qualities Save(Qualities entity)
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
    public List<Qualities> Search(Qualities entity, string type)
    {
        Expression<Func<Qualities, bool>>? conditions = null;
        switch (type.ToUpper())
        {
            case "NAME": conditions = x => x.Name!.Contains(entity.Name); break;
            default: conditions = x => x.Id == entity.Id; break;
        }

        return this.iRespository!.Search(conditions);
    }
    public Qualities Modify(Qualities entity)
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
    public Qualities Delete(Qualities entity)
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
}