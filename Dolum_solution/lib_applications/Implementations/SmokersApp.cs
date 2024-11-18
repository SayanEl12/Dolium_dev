using lib_entities;
using lib_applications.Interfaces;
using lib_repositories.Interfaces;
using lib_repositories;
using System.Linq.Expressions;

namespace lib_applications.Implementations;
public class SmokersApp : ISmokersApp
{
    private ISmokersRespository iRespository;
    
    public SmokersApp(ISmokersRespository iRespository)
    {
        this.iRespository = iRespository;
    }
    
    public void Configure(string stringConnection)
    {
        this.iRespository!.Configure(stringConnection);
    }
    
    public List<Smokers> GetList()
    {
        return this.iRespository!.GetList();
    }

    public Smokers Save(Smokers entity)
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

    public List<Smokers> Search(Smokers entity, string type)
    {
        Expression<Func<Smokers, bool>>? conditions = null;
        switch (type.ToUpper())
        {
            case "WIDTH": conditions = x => x.Width!.Equals(entity.Width); break;
            case "HEIGHT": conditions = x => x.Height!.Equals(entity.Height); break;
            case "POUNDS": conditions = x => x.Pounds!.Equals(entity.Pounds); break;
            case "PRICE_REF": conditions = x => x.Price_ref!.Equals(entity.Price_ref); break;
            case "DETAIL": conditions = x => x.Detail!.Contains(entity.Detail); break;
            case "STOCK": conditions = x => x.Stock!.Equals(entity.Stock); break;
            default: conditions = x => x.Id == entity.Id; break;
        }

        return this.iRespository!.Search(conditions);
    }
    
    public Smokers Modify(Smokers entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id != 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Modify(entity);
    }
    
    public Smokers Delete(Smokers entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id != 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this.iRespository!.Delete(entity);
    }
}