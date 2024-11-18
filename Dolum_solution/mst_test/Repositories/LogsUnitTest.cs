using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using mst_test.Core;
using Assert = NUnit.Framework.Assert;
using Microsoft.EntityFrameworkCore;
using lib_entities;
using lib_repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace mst_test.Repositories;
[TestClass]
public class LogsUnitTest
{
    private ILogsRepository? iRepository = null;
    private Logs? entity = null;

    public LogsUnitTest()
    {
        var connection = new Connection();
        connection.StringConnection = Configuration.GetValue("string_connection");
        iRepository = new LogsRepository(connection);
    }
    [TestMethod]
    public void Ejecutar()
    {
        Save();
        GetList();
        Search();
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
        entity = new Logs()
        {
            FrKey_User = 1,
            Description= "no tiene descripcion",
            Date= DateTime.Now

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
        entity!.Description = "Si tiene";
        entity = iRepository!.Modify(entity);
        Assert.IsTrue(entity.Id != 0);
    }
    private void Delete()
    {
        entity = iRepository!.Delete(entity!);

        Assert.IsTrue(entity.Id != 0);
    }

}