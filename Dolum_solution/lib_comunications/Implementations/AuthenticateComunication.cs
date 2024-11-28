using lib_comunications.Interfaces;
 
namespace lib_comunications.Implementations;
public class AuthenticateComunication : IAuthenticateComunication
{
    private Comunications? _comunications = null;
    private string? Name = "Authenticate";
    public AuthenticateComunication()
    {
        _comunications = new Comunications(Name);
    }
    public async Task<Dictionary<string, object>> Authenticate(Dictionary<string, object> data)
    {
        data = _comunications!.BuildUrlToken(data);
        return await _comunications!.Authenticate(data);
    }
    
}