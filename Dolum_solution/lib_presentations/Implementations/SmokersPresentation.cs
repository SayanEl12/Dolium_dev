using lib_comunications.Interfaces;
using lib_entities;
using lib_presentations.Interfaces;
using lib_comunications;
using lib_utilities;

namespace lib_presentations.Implementations;
public class SmokersPresentation
{
    private ISmokersComunication? iComunication = null;
    public SmokersPresentation(ISmokersComunication iComunication)
    {
        this.iComunication = iComunication;
    }
    public async Task<List<Smokers>> GetList()
    {
        var list = new List<Smokers>();
        var data = new Dictionary<string, object>();
        
        var answer = await iComunication!.GetList(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }
        list = JsonConverter.ConvertToObject<List<Smokers>>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return list;
    }
    public async Task<List<Smokers>> Search(Smokers entity, string type)
    {
        var list = new List<Smokers>();
        var data = new Dictionary<string, object>();
        data["Entity"] = entity;
        data["type"] = type;
        
        var answer = await iComunication!.Search(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }
        list = JsonConverter.ConvertToObject<List<Smokers>>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return list;
    }
    public async Task<Smokers> Save(Smokers entity)
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
        entity = JsonConverter.ConvertToObject<Smokers>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return entity;
    }
    public async Task<Smokers> Delete(Smokers entity)
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
        entity = JsonConverter.ConvertToObject<Smokers>(
            JsonConverter.ConvertToString(answer["Entities"]));
        return entity;
    }
}