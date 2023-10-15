namespace Poc.Common;

using System.ComponentModel;
using System.IO.Compression;
using System.Reflection;
using System.Text.Json;

public static class TypedJson
{
    public static JsonSerializerOptions JsonSerializerOptions { get; } = new()
    {
        //UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Disallow,
        PropertyNameCaseInsensitive = true,
    };

    public static string Serialize<T>(T msg, JsonSerializerOptions? jsonSerializerOptions = null) where T : notnull
    {
        jsonSerializerOptions ??= JsonSerializerOptions;

        var assembly = msg.GetType().Assembly.GetName().Name;
        var type = msg.GetType().FullName!;

        return @$"{{""A"":""{assembly}"",""T"":""{type}"",""V"":{JsonSerializer.Serialize(msg, jsonSerializerOptions)}}}";
    }

    public static object? Deserialize(string jsonString, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        jsonSerializerOptions ??= JsonSerializerOptions;

        var root = JsonDocument.Parse(jsonString).RootElement;

        var assembly = root.GetProperty("A").GetString()!;
        var typeName = root.GetProperty("T").GetString()!;

        var type = Assembly.Load(assembly).GetType(typeName)!;

        return root.GetProperty("V").Deserialize(type, jsonSerializerOptions);
    }
}

