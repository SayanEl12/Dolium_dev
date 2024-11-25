using lib_entities;
using lib_applications.Interfaces;
using lib_repositories.Interfaces;
using System.Linq.Expressions;

namespace lib_applications.Implementations;
public class SmokersApp : ISmokersApp
{
    private ISmokersRepository _iRepository;
    
    public SmokersApp(ISmokersRepository iRepository)
    {
        this._iRepository = iRepository;
    }
    
    public void Configure(string stringConnection)
    {
        this._iRepository!.Configure(stringConnection);
    }
    public List<Smokers> GetList()
    {
        return this._iRepository!.GetList();
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
        return this._iRepository!.Save(entity);
    }
    public List<Smokers> Search(Smokers entity, string type)
    {
        Expression<Func<Smokers, bool>>? conditions;
        switch (type.ToUpper())
        {
            case "WIDTH": conditions = x => x.Width!.Equals(entity.Width); break;
            case "HEIGHT": conditions = x => x.Height!.Equals(entity.Height); break;
            case "POUNDS": conditions = x => x.Pounds!.Equals(entity.Pounds); break;
            case "PRICE_REF": conditions = x => x.Price_ref!.Equals(entity.Price_ref); break;
            case "DETAIL": conditions = x => x.Detail!.Contains(entity!.Detail); break;
            case "STOCK": conditions = x => x.Stock!.Equals(entity.Stock); break;
            default: conditions = x => x.Id == entity.Id; break;
        }
        return this._iRepository!.Search(conditions);
    }
    public Smokers Modify(Smokers entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id == 0)
            throw new Exception("lbIdIsntZero");

        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this._iRepository!.Modify(entity);
    }
    public Smokers Delete(Smokers entity)
    {
        if (entity == null)
            throw new Exception("lbNullEntity");
        if (entity.Id == 0)
            throw new Exception("lbIdIsntZero");

        entity.Width = 0;
        entity.Height = 0;
        entity.Pounds = 0;
        entity.Price_ref = 0;
        entity.Detail = null;
        entity.Stock = 0;
        
        if (!entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        return this._iRepository!.Modify(entity);
    }
}