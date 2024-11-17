using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using mst_test.Core;
using Assert = NUnit.Framework.Assert;
using Microsoft.EntityFrameworkCore;
using lib_entities;
using lib_repositories;

namespace mst_test.Repositories;
[TestClass]
public class QualitiesUnitTest
{
    private IQualitiesRepository? iRepository=null;
    private Qualities? entity = null;

    public QualitiesUnitTest()
    {
        var connection = new Connection();
        connection.StringConnection = Configuration.GetValue("string_connection");
        iRepository = new QualitiesRepository (connection);
    }
    [TestMethod]
    public void Ejecutar()
    {
        GetList();
        Save();
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
        entity = new Qualities()
        {    
           
            Name = "admin"
        };
        entity = iRepository!.Save(entity);
        Assert.IsTrue(entity.Id != 0);
    }
    private void Modify()
    {
        entity!.Name = "Vendedor";
        entity = iRepository!.Modify(entity);
        Assert.IsTrue(entity.Id != 0);
    }
    private void Delete()
    {
        entity = iRepository!.Delete(entity!);

        Assert.IsTrue(entity.Id != 0);
    }

}