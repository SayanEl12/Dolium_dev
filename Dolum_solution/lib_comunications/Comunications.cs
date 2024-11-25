using lib_utilities;

namespace lib_comunications;
public class Comunications
{
    public string? Protocol = "http://",
        Host = "localhost:5201",
        Service = "asp_Smoker_services/",
        Name = string.Empty,
        token = null;

    public Comunications(string name)
    {
        Name = name;
    }

    public Dictionary<string, object> BuildUrl(Dictionary<string, object> data, string Method)
    {
        data["Url"] = Protocol + Host + "/" + Name + "/" + Method;
        data["UrlToken"] = Protocol + Host + "/" + Service + "Token/Authenticate" + Name;
        return data;
    }

    public async Task<Dictionary<string, object>> Execute(Dictionary<string, object> data)
    {
        var answer = new Dictionary<string, object>();
        try
        {
            /*
             * answer = await Authenticate(datos);
               if (answer == null || answer.ContainsKey("Error"))
               return answer!;
               respuesta.Clear();
             */
            var url = data["Url"].ToString();
            data.Remove("Url");
            data.Remove("UrlToken");
            data["Bearer"] = token!;
            var stringData = JsonConverter.ConvertToString(data);

            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 1, 30);
            
            var message = await httpClient.PostAsync(url, new StringContent(stringData));

            if (!message.IsSuccessStatusCode)
            {
                answer.Add("Error", "lbComunicationsError");
                return answer;
            }
            
            var response = await message.Content.ReadAsStringAsync();
            httpClient.Dispose();
            httpClient = null;

            if (string.IsNullOrEmpty(response))
            {
                answer.Add("Error", "lbAuthenticationError");
                return answer;
            }

            response = Replace(response);
            answer = JsonConverter.ConvertToObject(response);
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.ToString();
        }
        return answer;
    }

    public async Task<Dictionary<string, object>> Authenticate(Dictionary<string, object> data)
    {
        var answer = new Dictionary<string, object>();
        try
        {
            var url = data["Url"].ToString();
            var temp = new Dictionary<string, object>();
            temp["User"] = GeneralData.user_data;
            var stringData = JsonConverter.ConvertToString(temp);

            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 1, 30);
            var message = await httpClient.PostAsync(url, new StringContent(stringData));

            if (!message.IsSuccessStatusCode)
            {
                answer.Add("Error", "lbComunicationsError");
                return answer;
            }

            var resp = await message.Content.ReadAsStringAsync();
            httpClient.Dispose();
            httpClient = null;

            if (string.IsNullOrEmpty(resp))
            {
                answer.Add("Error", "lbAuthenticationError");
                return answer;
            }

            resp = Replace(resp);
            answer = JsonConverter.ConvertToObject(resp);
            token = answer["Token"].ToString();
        }
        catch (Exception ex)
        {
            answer["Error"] = ex.ToString();
        }

        return answer;
    }
    private string Replace(string resp)
    {
        return resp.Replace("\\\\r\\\\n", "")
            .Replace("\\r\\n", "")
            .Replace("\\", "")
            .Replace("\\\"", "\"")
            .Replace("\"", "'")
            .Replace("'[", "[")
            .Replace("]'", "]")
            .Replace("'{'", "{'")
            .Replace("\\\\", "\\")
            .Replace("'}'", "'}")
            .Replace("}'", "}")
            .Replace("\\n", "")
            .Replace("\\r", "").Replace(" ", "")
            .Replace("'{", "{")
            .Replace("\"", "")
            .Replace(" ", "")
            .Replace("null", "''");
    }
}