namespace Poc.Dto;

public record PersonDto
{
    public required string Name { get; init; }
    public required string PhoneNumber { get; init; }
}
