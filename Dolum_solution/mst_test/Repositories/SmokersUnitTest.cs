using lib_utilities;
using lib_entities;
using lib_repositories;
using lib_repositories.Interfaces;
using lib_repositories.Implementations;
using mst_test.Core;
using Assert = NUnit.Framework.Assert;

namespace mst_test.Repositories;
[TestClass]
public class SmokersUnitTest
{
    private ISmokersRespository? iRespository = null;
    private Smokers? entity = null;
    public SmokersUnitTest()
    {
        var connection = new Connection();
        connection.StringConnection = Configuration.GetValue("string_connection");
        iRespository = new SmokersRepository(connection);
    }
    [TestMethod]
    public void Ejecutar()
    {
        Save();
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
        entity = iRespository!.Save(entity);
        Assert.IsTrue(entity.Id != 0);
    }
}