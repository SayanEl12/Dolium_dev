using lib_comunications.Interfaces;

namespace lib_comunications.Implementations;
public class ImagesComunication : IImagesComunication
{
    private Comunications? _comunications = null;
    private string? Name = "Images";
    public ImagesComunication()
    {
        _comunications = new Comunications(Name);
    }
    public async Task<Dictionary<string, object>> GetList(Dictionary<string, object> data)
    {
        data = _comunications!.BuildUrl(data, "GetList");
        return await _comunications!.Execute(data);
    }
    public async Task<Dictionary<string, object>> Save(Dictionary<string, object> data)
    {
        data = _comunications!.BuildUrl(data, "Save");
        return await _comunications!.Execute(data);
    }
    public async Task<Dictionary<string, object>> Search(Dictionary<string, object> data)
    {
        data = _comunications!.BuildUrl(data, "Search");
        return await _comunications!.Execute(data);
    }
    public async Task<Dictionary<string, object>> Modify(Dictionary<string, object> data)
    {
        data = _comunications!.BuildUrl(data, "Modify");
        return await _comunications!.Execute(data);
    }
    public async Task<Dictionary<string, object>> Delete(Dictionary<string, object> data)
    {
        data = _comunications!.BuildUrl(data, "Delete");
        return await _comunications!.Execute(data);
    }
}