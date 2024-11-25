using lib_comunications.Implementations;
using lib_comunications.Interfaces;
using lib_entities;
using lib_utilities;
namespace mst_pruebas.Comunicationes
{
    [TestClass]
    public class SmokersUnitaries
    {
        private ISmokersComunication? iComunication = null;
        private Smokers? entity = null;
        private List<Smokers>? lista = null;
        public SmokersUnitaries()
        {
            iComunication = new SmokersComunication();
        }
        [TestMethod]
        public void Execute()
        {
            Save();
            GetList();
            Search();
            Modify();
            Delete();
        }
        private void GetList()
        {
            var data = new Dictionary<string, object>();
            var task = iComunication!.GetList(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            lista = JsonConverter.ConvertToObject<List<Smokers>>(
                JsonConverter.ConvertToString(data["Entities"]));
        }
        private void Search()
        {
            var data = new Dictionary<string, object>();
            data["Entity"] = entity!;
            data["Type"] = "DETAIL";
            var task = iComunication!.Search(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            lista = JsonConverter.ConvertToObject<List<Smokers>>(
                JsonConverter.ConvertToString(data["Entities"]));
        }
        public void Save()
        {
            var data = new Dictionary<string, object>();
            entity = new Smokers()
            {
                Width = 10,
                Height = 10,
                Pounds = 10,
                Price_ref  = 10,
                Detail = "a",
                Stock = 10
            };
            NUnit.Framework.Assert.IsTrue(entity.Validate());
            data["Entity"] = entity!;
            var task = iComunication!.Save(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Smokers>(
                JsonConverter.ConvertToString(data["Entities"]));
        }
        public void Modify()
        {
            var data = new Dictionary<string, object>();
            entity!.Detail = "Juanchito@gmail.com";
            data["Entity"] = entity!;
            var task = iComunication!.Modify(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Smokers>(
                JsonConverter.ConvertToString(data["Entities"]));
        }
        public void Delete()
        {
            var data = new Dictionary<string, object>();
            data["entity"] = entity!;
            var task = iComunication!.Delete(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Smokers>(
                JsonConverter.ConvertToString(data["entity"]));
        }
    }
}
