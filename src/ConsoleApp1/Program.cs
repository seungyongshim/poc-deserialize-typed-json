using Poc.Common;
using Poc.Dto;


var value = new Class1
{
    Value = "Hello"
};

var str = TypedJson.Serialize(value);

var a = TypedJson.Deserialize("""
    {"A":"Poc.Dto","T":"Poc.Dto.Class1","V":{"Value":"Hello1","B":{"C": "B"}}}
    """);

Console.WriteLine(a);
