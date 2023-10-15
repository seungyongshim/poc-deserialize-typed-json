using AutoMapper;
using Poc.Domain;
using Poc.Dto;

var mapperConfiguration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<PersonDto, Person>();
    cfg.CreateMap<string, PhoneNumber>()
       .ForMember
       (
            d => d.RegionCode,
            o => o.MapFrom(src => src)
       );
    cfg.DisableConstructorMapping();

});

var mapper = mapperConfiguration.CreateMapper();


var people = mapper.Map<Person>(new PersonDto
{
    Name = "Simpson",
    PhoneNumber = "+82-123456789"
});

var peopleDto = mapper.Map<PersonDto>(people);

Console.WriteLine(people);
