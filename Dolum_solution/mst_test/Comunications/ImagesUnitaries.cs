using lib_comunications.Implementations;
using lib_comunications.Interfaces;
using lib_entities;
using lib_utilities;
namespace mst_pruebas.Comunicationes
{
    [TestClass]
    public class ImagesUnitaries
    {
        private IImagesComunication? iComunication = null;
        private Images? entity = null;
        private List<Images>? lista = null;
        public ImagesUnitaries()
        {
            iComunication = new ImagesComunication();
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
            lista = JsonConverter.ConvertToObject<List<Images>>(
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
            lista = JsonConverter.ConvertToObject<List<Images>>(
                JsonConverter.ConvertToString(data["entityes"]));
        }
        public void Save()
        {
            var data = new Dictionary<string, object>();
            entity = new Images()
            {
                Url = "Juan",
            };
            NUnit.Framework.Assert.IsTrue(entity.Validate());
            data["Entity"] = entity!;
            var task = iComunication!.Save(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Images>(
                JsonConverter.ConvertToString(data["Entities"]));
        }
        public void Modify()
        {
            var data = new Dictionary<string, object>();
            entity!.Url = "Juanchito@gmail.com";
            data["Entity"] = entity!;
            var task = iComunication!.Modify(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Images>(
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
            entity = JsonConverter.ConvertToObject<Images>(
                JsonConverter.ConvertToString(data["entity"]));
        }
    }
}
