using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using mst_test.Core;
using Assert = NUnit.Framework.Assert;
using Microsoft.EntityFrameworkCore;
using lib_entities;
using lib_repositories;

namespace mst_test.Repositories;
[TestClass]
public class SalesUnitTest
{
    private ISalesRepository? iRepository = null;
    private Sales? entity = null;

    public SalesUnitTest()
    {
        var connection = new Connection();
        connection.StringConnection = Configuration.GetValue("string_connection");
        iRepository = new SalesRepository(connection);
    }
    [TestMethod]
    public void Ejecutar()
    {
        GetList();
        Save();
        Modify();
        Search();
        Delete();
    }
    private void GetList()
    {
        var list = iRepository!.GetList();
        Assert.IsTrue(list.Count > 0);
    }
    private void Save()
    {
        entity = new Sales()
        {

            FrKey_Customer = 2,
            FrKey_Seller = 3,
            Date = DateTime.Now,
            Value= 900000.0m,
            Address = "Medellin"
        };
        entity = iRepository!.Save(entity);
        Assert.IsTrue(entity.Id != 0);
    }
    public void Search()
    {
        var lista = iRepository!.Search(x => x.Id == entity!.Id);
        Assert.IsTrue(lista.Count > 0);
    }
    private void Modify()
    {
        entity!.Address= "Bogota";
        entity = iRepository!.Modify(entity);
        Assert.IsTrue(entity.Id != 0);
    }
    private void Delete()
    {
        entity = iRepository!.Delete(entity!);

        Assert.IsTrue(entity.Id != 0);
    }

}