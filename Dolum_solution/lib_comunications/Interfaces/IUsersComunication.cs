namespace lib_comunications.Interfaces;

public interface IUsersComunication
{
    Task<Dictionary<string, object>> GetList(Dictionary<string, object> data);
    Task<Dictionary<string, object>> Search(Dictionary<string, object> data);
    Task<Dictionary<string, object>> Save(Dictionary<string, object> data);
    Task<Dictionary<string, object>> Modify(Dictionary<string, object> data);
    Task<Dictionary<string, object>> Delete(Dictionary<string, object> data);
}