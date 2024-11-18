using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using mst_test.Core;
using Assert = NUnit.Framework.Assert;
using Microsoft.EntityFrameworkCore;
using lib_entities;
using lib_repositories;

namespace mst_test.Repositories;
[TestClass]
public class Sale_ProductUnitTest
{
    private ISale_ProductRepository? iRepository;
    private Sale_Product? entity = null;

    public Sale_ProductUnitTest()
    {
        var connection = new Connection();
        connection.StringConnection = Configuration.GetValue("string_connection");
        iRepository = new Sale_ProductRepository(connection);
    }
    [TestMethod]
    public void Ejecutar()
    {
        Save();
        GetList();
        Modify();
        Delete();
    }
    private void GetList()
    {
        var list = iRepository!.GetList();
        Assert.IsTrue(list.Count > 0);
    }
    private void Save()
    {
        entity = new Sale_Product()
        {

            FrKey_Sale = 2,
            FrKey_Smoker = 3,
            Cant = 30
            
        };
        entity = iRepository!.Save(entity);
        Assert.IsTrue(entity.FrKey_Sale != 0);
    }
    public void Search()
    {
        var lista = iRepository!.Search(x => x.Id == entity!.Id);
        Assert.IsTrue(lista.Count > 0);
    }
    private void Modify()
    {
        entity!.FrKey_Sale = 4;
        entity = iRepository!.Modify(entity);
        Assert.IsTrue(entity.FrKey_Sale != 0);
    }
    private void Delete()
    {
        entity = iRepository!.Delete(entity!);

        Assert.IsTrue(entity.FrKey_Sale != 0);
    }

}