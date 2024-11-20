using lib_comunications.Interfaces;
using lib_entities;
using lib_presentations.Interfaces;
using lib_comunications;
using lib_utilities;

namespace lib_presentations.Implementations;
public class SalesPresentation
{
    private ISalesComunication? iComunication = null;
    public SalesPresentation(ISalesComunication iComunication)
    {
        this.iComunication = iComunication;
    }
    public async Task<List<Sales>> GetList()
    {
        var list = new List<Sales>();
        var data = new Dictionary<string, object>();

        var answer = await iComunication!.GetList(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }
        list = JsonConverter.ConvertToObject<List<Sales>>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return list;
    }
    public async Task<List<Sales>> Search(Sales entity, string type)
    {
        var list = new List<Sales>();
        var data = new Dictionary<string, object>();
        data["Entity"] = entity;
        data["type"] = type;

        var answer = await iComunication!.Search(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }
        list = JsonConverter.ConvertToObject<List<Sales>>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return list;
    }
    public async Task<Sales> Save(Sales entity)
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
        entity = JsonConverter.ConvertToObject<Sales>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return entity;
    }
    public async Task<Sales> Delete(Sales entity)
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
        entity = JsonConverter.ConvertToObject<Sales>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return entity;
    }
}