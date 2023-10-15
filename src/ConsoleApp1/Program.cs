
using System.Text.Json;
using A2;
using A2.Dto;
using Poc.Common;


var value = new Class1
{
    Value = "Hello"
};

var str = TypedJson.Serialize(value);


var a = TypedJson.Deserialize("""
    {"A":"A2","T":"A2.Dto.Class1","V":{"Value":"Hello","B":"B"}}
    """);

Console.WriteLine(a);
