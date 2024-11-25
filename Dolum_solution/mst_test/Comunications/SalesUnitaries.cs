using lib_comunications.Implementations;
using lib_comunications.Interfaces;
using lib_entities;
using lib_utilities;
namespace mst_pruebas.Comunicationes
{
    [TestClass]
    public class SalesUnitaries
    {
        private ISalesComunication? iComunication = null;
        private Sales? entity = null;
        private List<Sales>? lista = null;
        public SalesUnitaries()
        {
            iComunication = new SalesComunication();
        }
        [TestMethod]
        public void Execute()
        {
            Save();
            GetList();
            //Search();
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
            lista = JsonConverter.ConvertToObject<List<Sales>>(
                JsonConverter.ConvertToString(data["Entities"]));
        }
        private void Search()
        {
            var data = new Dictionary<string, object>();
            data["entity"] = entity!;
            data["Tipo"] = "NOMBRE";
            var task = iComunication!.Search(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            lista = JsonConverter.ConvertToObject<List<Sales>>(
                JsonConverter.ConvertToString(data["entityes"]));
        }
        public void Save()
        {
            var data = new Dictionary<string, object>();
            entity = new Sales()
            {
                FrKey_Customer = 1,
                FrKey_Seller = 1,
                Date = DateTime.Now,
                Value = 2,
                Address = "a"
            };
            NUnit.Framework.Assert.IsTrue(entity.Validate());
            data["Entity"] = entity!;
            var task = iComunication!.Save(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Sales>(
                JsonConverter.ConvertToString(data["Entities"]));
        }
        public void Modify()
        {
            var data = new Dictionary<string, object>();
            entity!.Address = "Juanchito@gmail.com";
            data["Entity"] = entity!;
            var task = iComunication!.Modify(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Sales>(
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
            entity = JsonConverter.ConvertToObject<Sales>(
                JsonConverter.ConvertToString(data["entity"]));
        }
    }
}
