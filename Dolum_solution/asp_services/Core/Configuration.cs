using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using lib_utilities;

namespace asp_services.Core;
public class Configuration
{
    private static Dictionary<string, string>? data;
    
    public string? this[string key]
    {
        get { return data![key]; }
        set { data![key] = value!; }
    }
    public static void Load()
    {
        data = new Dictionary<string, string>();
        StreamReader jsonStream = File.OpenText(GeneralData.json_path);
        var json = jsonStream.ReadToEnd();
        var temp = JsonConvert.DeserializeObject<Dictionary<string, string>>(json)!;
        foreach (var elemet in temp)
            data[elemet.Key] = elemet.Value;
    }
    public static string GetValue(string clave)
    {
        if (data == null)
            Load();
        return data![clave]!.ToString()!;
    }
}