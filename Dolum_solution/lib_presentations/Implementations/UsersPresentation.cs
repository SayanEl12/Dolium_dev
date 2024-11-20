using lib_comunications.Interfaces;
using lib_entities;
using lib_presentations.Interfaces;
using lib_comunications;
using lib_utilities;

namespace lib_presentations.Implementations;
public class UsersPresentation : IUsersPresentation
{
    private IUsersComunication? iComunication = null;
    public UsersPresentation(IUsersComunication iComunication)
    {
        this.iComunication = iComunication;
    }
    public async Task<List<Users>> GetList()
    {
        var list = new List<Users>();
        var data = new Dictionary<string, object>();

        var answer = await iComunication!.GetList(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }
        list = JsonConverter.ConvertToObject<List<Users>>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return list;
    }
    public async Task<List<Users>> Search(Users entity, string type)
    {
        var list = new List<Users>();
        var data = new Dictionary<string, object>();
        data["Entity"] = entity;
        data["type"] = type;

        var answer = await iComunication!.Search(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }
        list = JsonConverter.ConvertToObject<List<Users>>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return list;
    }
    public async Task<Users> Save(Users entity)
    {
        if (entity.Id != 0 || !entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        var data = new Dictionary<string, object>();
        data["Entity"] = entity;

        var answer = await iComunication!.Save(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }
        entity = JsonConverter.ConvertToObject<Users>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return entity;
    }
    public async Task<Users> Delete(Users entity)
    {
        if (entity.Id == 0 || !entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        var data = new Dictionary<string, object>();
        data["Entity"] = entity;

        var answer = await iComunication!.Delete(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }
        entity = JsonConverter.ConvertToObject<Users>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return entity;
    }
    public async Task<Users> Modify(Users entity)
    {
        if (entity.Id == 0 || !entity.Validate())
        {
            throw new Exception("lbWrongData");
        }
        var data = new Dictionary<string, object>();
        data["Entity"] = entity;

        var answer = await iComunication!.Modify(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }
        entity = JsonConverter.ConvertToObject<Users>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return entity;
    }
}