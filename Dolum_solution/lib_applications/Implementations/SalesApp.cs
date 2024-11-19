using lib_entities;
using lib_applications.Interfaces;
using lib_repositories.Interfaces;
using System.Linq.Expressions;

namespace lib_applications.Implementations;
public class SalesApp : ISalesApp
{
    private ISalesRepository iRespository;
    
    public SalesApp(ISalesRepository iRespository)
    {
        this.iRespository = iRespository;
    }
    
    public void Configure(string stringConnection)
    {
        this.iRespository!.Configure(stringConnection);
    }
    
    public List<Sales> GetList()
    {
        return this.iRespository!.GetList();
    }
    public Sales Save(Sales entity)
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
    public List<Sales> Search(Sales entity, string type)
    {
        Expression<Func<Sales, bool>>? conditions = null;
        switch (type.ToUpper())
        {
            case "CUSTOMER": conditions = x => x.FrKey_Customer!.Equals(entity.FrKey_Customer); break;
            case "SELLER": conditions = x => x.FrKey_Seller!.Equals(entity.FrKey_Seller); break;
            case "POUNDS": conditions = x => x.Date!.Equals(entity.Date); break;
            case "PRICE_REF": conditions = x => x.Value!.Equals(entity.Value); break;
            case "DETAIL": conditions = x => x.Address!.Contains(entity.Address); break;
            default: conditions = x => x.Id == entity.Id; break;
        }

        return this.iRespository!.Search(conditions);
    }
    public Sales Modify(Sales entity)
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
    public Sales Delete(Sales entity)
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