using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using lib_utilities;
using lib_applications.Interfaces;
using lib_entities;
using System.Security.Claims;
using System.Text;
using asp_services.Core;
using lib_applications.Implementations;

namespace asp_services.Controllers;
public class TokenController : ControllerBase
{
    private IUsersApp? iUsersApp = null;

    public TokenController(IUsersApp iUsersApp)
    {
        this.iUsersApp = iUsersApp;
    }
    
    private Dictionary<string, object> GetData()
    {
        var answer = new Dictionary<string, object>();
        try
        {
            var data = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(data))
                data = "{}";
            return JsonConverter.ConvertToObject(data);
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.Message.ToString();
            return answer;
        }
    }
    
    [HttpPost]
    [AllowAnonymous]
    [Route("Token/Authenticate")]
    public string Authenticate()
    {
        var answer = new Dictionary<string, object>();
        try
        {
            var data = GetData();
            if (!data.ContainsKey("Email") ||!data.ContainsKey("Password") ||
                !validateCredentials(data["Email"].ToString()!, data["Password"].ToString()!))
            {
                answer["Error"] = "lbNoAuthentication";
                return JsonConverter.ConvertToString(answer);
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, data["Email"].ToString()!)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GeneralData.key)),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            answer["Token"] = tokenHandler.WriteToken(token);
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.ToString();
        }
        return JsonConverter.ConvertToString(answer);
    }

    private bool validateCredentials(string email, string password)
    {
        this.iUsersApp!.Configure(Configuration.GetValue("string_connection"));
        Users users = new Users();
        users.Email = EncrypConverter.Decrypt(email);
        users.Password = EncrypConverter.Decrypt(password);
        
        if (iUsersApp.Search(users, "Email").Count < 1)
            return false;
        if (iUsersApp.Search(users, "Password").Count < 1)
            return false;
        return true;
    }
    
    public bool Validate(Dictionary<string, object> data)
    {
        try
        {
            var authorizationHeader = data["Bearer"].ToString();
            authorizationHeader = authorizationHeader!.Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.ReadToken(authorizationHeader);
            if (DateTime.UtcNow > token.ValidTo)
                return false;
            return true;
        }
        catch
        {
            return false;
        }
    }
}