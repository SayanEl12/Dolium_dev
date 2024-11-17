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
public class ImagesUnitTest
{
    private IImagesRepository? iRepository = null;
    private Images? entity = null;

    public ImagesUnitTest()
    {
        var connection = new Connection();
        connection.StringConnection = Configuration.GetValue("string_connection");
        iRepository = new ImagesRepository(connection);
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
        entity = new Images()
        {

            Id_Smoker =1,
            Url="HTTPS"
        };
        entity = iRepository!.Save(entity);
        Assert.IsTrue(entity.Id != 0);
    }
  

    private void Modify()
    {
        entity!.Url= "HTTP";
        entity = iRepository!.Modify(entity);
        Assert.IsTrue(entity.Id != 0);
    }
    private void Delete()
    {
        entity = iRepository!.Delete(entity!);

        Assert.IsTrue(entity.Id != 0);
    }


}