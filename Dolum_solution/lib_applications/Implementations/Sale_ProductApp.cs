using lib_entities;
using lib_applications.Interfaces;
using lib_repositories.Interfaces;
using System.Linq.Expressions;

namespace lib_applications.Implementations;
public class Sale_ProductApp : ISale_ProductApp
{
    private ISale_ProductRepository iRespository;
    
    public Sale_ProductApp(ISale_ProductRepository iRespository)
    {
        this.iRespository = iRespository;
    }
    
    public void Configure(string stringConnection)
    {
        this.iRespository!.Configure(stringConnection);
    }
    
    public List<Sale_Product> GetList()
    {
        return this.iRespository!.GetList();
    }
    
    public Sale_Product Save(Sale_Product entity)
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
    
    public List<Sale_Product> Search(Sale_Product entity, string type)
    {
        Expression<Func<Sale_Product, bool>>? conditions = null;
        switch (type.ToUpper())
        {
            case "SALE": conditions = x => x.FrKey_Sale!.Equals(entity.FrKey_Sale); break;
            case "SMOKER": conditions = x => x.FrKey_Smoker!.Equals(entity.FrKey_Smoker); break;
            case "CANT": conditions = x => x.Cant!.Equals(entity.Cant); break;
            default: conditions = x => x.Id == entity.Id; break;
        }

        return this.iRespository!.Search(conditions);
    }
    
    public Sale_Product Modify(Sale_Product entity)
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
    
    public Sale_Product Delete(Sale_Product entity)
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

    public List<Sale_Product> DeleteProduct(int Id)
    {   
        List<Sale_Product> Sale_ProductDeleted = new List<Sale_Product>();
        Sale_Product Sale_prodToDel = new Sale_Product();
        List<Sale_Product> Sale_ProductToDelete = new List<Sale_Product>();
        try
        {
            Sale_prodToDel.FrKey_Smoker = Id;
            Sale_ProductToDelete = Search(Sale_prodToDel, "SMOKER");
        }
        catch (Exception ex)
        {
            throw new Exception("Error en primera parte");
        }

        try
        {
            foreach (var s_p in Sale_ProductToDelete)
            {
                s_p.FrKey_Smoker = 1;
                var s_pDel = Modify(s_p);
                Sale_ProductDeleted.Add(s_pDel);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error en la segunda parte");
        }
        
        foreach (var s_p in Sale_ProductToDelete)
        {
            s_p.FrKey_Smoker = 1;
            var s_pDel = Modify(s_p);
            Sale_ProductDeleted.Add(s_pDel);
        }
        return Sale_ProductDeleted;
    }
}