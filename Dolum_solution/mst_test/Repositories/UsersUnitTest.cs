using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using mst_test.Core;
using Assert = NUnit.Framework.Assert;
using Microsoft.EntityFrameworkCore;
using lib_entities;
using lib_repositories;

namespace mst_test.Repositories;
[TestClass]
public class UsersUnitTest
{
    private IUsersRepository? iRepository = null;
    private Users? entity = null;

    public UsersUnitTest()
    {
        var connection = new Connection();
        connection.StringConnection = Configuration.GetValue("string_connection");
        iRepository = new UsersRepository(connection);
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
        entity = new Users()
        {

            Name = "Juan",
            Email = "Juan@gmail.com",
            Quality = 1,
            Password = "Literalmente cualquier cosa :)",
            Register_date = DateTime.Now
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
        entity!.Email = "Juanchito@gmail.com";
        entity = iRepository!.Modify(entity);
        Assert.IsTrue(entity.Id != 0);
    }
    private void Delete()
    {
        entity = iRepository!.Delete(entity!);

        Assert.IsTrue(entity.Id != 0);
    }

}