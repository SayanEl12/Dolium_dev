using lib_comunications.Interfaces;
using lib_entities;
using lib_presentations.Interfaces;
using lib_comunications;
using lib_utilities;

namespace lib_presentations.Implementations;

public class AuthenticatePresentation : IAuthenticatePresentation
{
    private IAuthenticateComunication? iComunication = null;

    public AuthenticatePresentation(IAuthenticateComunication iComunication)
    {
        this.iComunication = iComunication;
    }

    public async Task<string> Authenticate(string Email, string Password)
    {
        string token = "";
        var data = new Dictionary<string, object>();
        data["Email"] = EncrypConverter.Encrypt(Email);
        data["Password"] = EncrypConverter.Encrypt(Password);

        var answer = await iComunication!.Authenticate(data);
        if (answer.ContainsKey("Error"))
        {
            throw new Exception(answer["Error"].ToString()!);
        }

        token = JsonConverter.ConvertToObject<string>(
            JsonConverter.ConvertToString(answer["Token"]));
        return token;
    }
}