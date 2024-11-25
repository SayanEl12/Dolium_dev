using asp_services.Core;
using lib_applications.Interfaces;
using lib_entities;
using Microsoft.AspNetCore.Mvc;

namespace asp_services.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class SmokersController : ControllerBase
{
    private ISmokersApp? IApp = null;
    private ISale_ProductApp? ISale_ProductApp = null;
    public SmokersController(ISmokersApp? IApp, ISale_ProductApp? ISale_ProductApp)
    {
        this.IApp = IApp;
        this.ISale_ProductApp = ISale_ProductApp;
    }

    private Dictionary<string, object> GetData()
    {
        var answer = new Dictionary<string, object>();
        try
        {
            var data = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(data))
                data = "{}";
            return lib_utilities.JsonConverter.ConvertToObject(data);
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.Message.ToString();
            return answer;
        }
    }

    [HttpPost]
    public string GetList()
    {
        var answer = new Dictionary<string, object>();
        try
        {
            var data = GetData();
            /*if (!tokenController!.Validate(datos))
            {
                respuesta["Error"] = "lbNoAutenticacion";
                return JsonConversor.ConvertirAString(respuesta);
            }*/

            this.IApp!.Configure(Configuration.GetValue("string_connection"));
            answer["Entities"] = this.IApp!.GetList();

            answer["Answer"] = "OK";
            answer["Date"] = DateTime.Now.ToString();
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.Message.ToString();
        }
        return lib_utilities.JsonConverter.ConvertToString(answer);
    }
    [HttpPost]
    public string Save()
    {
        var answer = new Dictionary<string, object>();
        try
        {
            var data = GetData();
            /*if (!tokenController!.Validate(datos))
            {
                respuesta["Error"] = "lbNoAutenticacion";
                return JsonConversor.ConvertirAString(respuesta);
            }*/
            var entity = lib_utilities.JsonConverter.ConvertToObject<Smokers>(
                lib_utilities.JsonConverter.ConvertToString(data["Entity"]));
            
            this.IApp!.Configure(Configuration.GetValue("string_connection"));
            answer["Entities"] = this.IApp!.Save(entity);

            answer["Answer"] = "OK";
            answer["Date"] = DateTime.Now.ToString();
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.Message.ToString();
        }
        return lib_utilities.JsonConverter.ConvertToString(answer);
    }
    [HttpPost]
    public string Modify()
    {
        var answer = new Dictionary<string, object>();
        try
        {
            var data = GetData();
            /*if (!tokenController!.Validate(data))
            {
                answer["Error"] = "lbNoAutenticacion";
                return JsonConversor.ConvertirAString(answer);
            }*/
            var entity = lib_utilities.JsonConverter.ConvertToObject<Smokers>(
                lib_utilities.JsonConverter.ConvertToString(data["Entity"]));
            
            this.IApp!.Configure(Configuration.GetValue("string_connection"));
            answer["Entities"] = this.IApp!.Modify(entity);

            answer["Answer"] = "OK";
            answer["Date"] = DateTime.Now.ToString();
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.Message.ToString();
        }
        return lib_utilities.JsonConverter.ConvertToString(answer);
    }
    [HttpPost]
    public string Delete() 
    {
        var answer = new Dictionary<string, object>();
        try
        {
            var data = GetData();
            var entity = lib_utilities.JsonConverter.ConvertToObject<Smokers>(
                lib_utilities.JsonConverter.ConvertToString(data["Entity"]));
            
            this.IApp!.Configure(Configuration.GetValue("string_connection"));
            try
            {
                answer["Logs"] = this.ISale_ProductApp!.DeleteProduct(entity.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  en logs");
            }
            
            answer["Entities"] = this.IApp!.Delete(entity);

            answer["Answer"] = "OK";
            answer["Date"] = DateTime.Now.ToString();
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.Message.ToString();
        }
        return lib_utilities.JsonConverter.ConvertToString(answer);
    }

    [HttpPost]
    public string Search()
    {
        var answer = new Dictionary<string, object>();
        try
        {
            var data = GetData();
            var entity = lib_utilities.JsonConverter.ConvertToObject<Smokers>(
                lib_utilities.JsonConverter.ConvertToString(data["Entity"]));
            string type = data["Type"].ToString();
            
            this.IApp!.Configure(Configuration.GetValue("string_connection"));
            answer["Entities"] = this.IApp!.Search(entity, type);

            answer["Answer"] = "OK";
            answer["Date"] = DateTime.Now.ToString();
            
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.Message.ToString();
        }
        return lib_utilities.JsonConverter.ConvertToString(answer);
    }
}