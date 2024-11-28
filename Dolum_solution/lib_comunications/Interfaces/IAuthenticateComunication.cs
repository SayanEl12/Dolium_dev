namespace lib_comunications.Interfaces;
public interface IAuthenticateComunication
{
    Task<Dictionary<string, object>> Authenticate(Dictionary<string, object> data);
}