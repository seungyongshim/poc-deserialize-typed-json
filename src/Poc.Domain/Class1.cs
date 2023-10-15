namespace Poc.Domain;

public readonly record struct RegionCode(string Value);
public readonly record struct PhoneNumberDetail(string Value);

public readonly record struct PhoneNumber
{
    public RegionCode RegionCode { get; init; }
    public PhoneNumberDetail PhoneNumberDetail { get; init;}
};

public readonly record struct Name(string Value);

public record Person
{
    public required PhoneNumber PhoneNumber { get; init; }
    public required Name Name { get; init; }
}
