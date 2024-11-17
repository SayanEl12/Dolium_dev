using lib_utilities;
using lib_entities;
using lib_repositories;
using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using mst_test.Core;
using Assert = NUnit.Framework.Assert;
using Microsoft.EntityFrameworkCore;

namespace mst_test.Repositories;
[TestClass]
public class SmokersUnitTest
{
    private ISmokersRespository? iRepository = null;
    private Smokers? entity = null;
    public SmokersUnitTest()
    {
        var connection = new Connection();
        connection.StringConnection = Configuration.GetValue("string_connection");
        iRepository = new SmokersRepository(connection);
    }
    [TestMethod]
    public void Ejecutar()
    {
        GetList();
        Save();
        Search();
        Modify();
        Delete();
    }
    private void GetList()
    {
        var list= iRepository!.GetList();
        Assert.IsTrue(list.Count > 0);
    }
    private void Save()
    {
        entity = new Smokers()
        {
            Width = 120.0m,
            Height = 120.0m,
            Pounds = 20.0m,
            Price_ref = 20.0m,
            Detail = "Literalmente cualquier cosa :)",
            Stock = 100
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
        entity!.Pounds = 100;
        entity = iRepository!.Modify(entity);
        Assert.IsTrue(entity.Id != 0);
    }
    private void Delete()
    {
        entity= iRepository!.Delete(entity!);
        
        Assert.IsTrue(entity.Id != 0);
    }

}