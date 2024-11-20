using lib_comunications.Implementations;
using lib_comunications.Interfaces;
using lib_entities;
using lib_utilities;
namespace mst_pruebas.Comunicationes
{
    [TestClass]
    public class UsersPruebaUnitaria
    {
        private IUsersComunication? iComunication = null;
        private Users? entity = null;
        private List<Users>? lista = null;
        public UsersPruebaUnitaria()
        {
            iComunication = new UsersComunication();
        }
        [TestMethod]
        public void Executar()
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
            Assert.IsTrue(!data.ContainsKey("Error"));
            lista = JsonConverter.ConvertToObject<List<Users>>(
                JsonConverter.ConvertToString(data["entityes"]));
        }
        private void Search()
        {
            var data = new Dictionary<string, object>();
            data["entity"] = entity!;
            data["Tipo"] = "NOMBRE";
            var task = iComunication!.Search(data);
            task.Wait();
            data = task.Result;
            Assert.IsTrue(!data.ContainsKey("Error"));
            lista = JsonConverter.ConvertToObject<List<Users>>(
                JsonConverter.ConvertToString(data["entityes"]));
        }
        public void Save()
        {
            var data = new Dictionary<string, object>();
            entity = new Users()
            {
                Persona = "Test 2",
                Nota1 = 1.2m,
                Nota2 = 2.5m,
                Nota3 = 4.5m,
                Nota4 = 3.8m,
                Nota5 = 4.3m,
                Final = 0.0m,
                Fecha = DateTime.Now,
            };
            data["entity"] = entity!;
            var task = iComunication!.Save(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Users>(
                JsonConverter.ConvertToString(data["entity"]));
        }
        public void Modify()
        {
            var data = new Dictionary<string, object>();
            entity!.Final = 3.0m;
            data["entity"] = entity!;
            var task = iComunication!.Modify(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Users>(
                JsonConverter.ConvertToString(data["entity"]));
        }
        public void Delete()
        {
            var data = new Dictionary<string, object>();
            data["entity"] = entity!;
            var task = iComunication!.Delete(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Users>(
                JsonConverter.ConvertToString(data["entity"]));
        }
    }
}
