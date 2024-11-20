using lib_comunications.Implementations;
using lib_comunications.Interfaces;
using lib_entities;
using lib_utilities;
namespace mst_pruebas.Comunicationes
{
    [TestClass]
    public class UsersUnitarias
    {
        private IUsersComunication? iComunication = null;
        private Users? entity = null;
        private List<Users>? lista = null;
        public UsersUnitarias()
        {
            iComunication = new UsersComunication();
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
            lista = JsonConverter.ConvertToObject<List<Users>>(
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
            lista = JsonConverter.ConvertToObject<List<Users>>(
                JsonConverter.ConvertToString(data["entityes"]));
        }
        public void Save()
        {
            var data = new Dictionary<string, object>();
            entity = new Users()
            {
                Name = "Juan",
                Email = "ASDFAS@gmail.com",
                Quality = 2,
                Password = "Literalmente cualquier cosa :)",
                Register_date = DateTime.Now
            };
            NUnit.Framework.Assert.IsTrue(entity.Validate());
            data["Entity"] = entity!;
            var task = iComunication!.Save(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Users>(
                JsonConverter.ConvertToString(data["Entities"]));
        }
        public void Modify()
        {
            var data = new Dictionary<string, object>();
            entity!.Email = "Juanchito@gmail.com";
            data["Entity"] = entity!;
            var task = iComunication!.Modify(data);
            task.Wait();
            data = task.Result;
            NUnit.Framework.Assert.IsTrue(!data.ContainsKey("Error"));
            entity = JsonConverter.ConvertToObject<Users>(
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
            entity = JsonConverter.ConvertToObject<Users>(
                JsonConverter.ConvertToString(data["entity"]));
        }
    }
}
