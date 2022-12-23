using AutoMapper;

namespace TamagochiPokemonAPI.Models;

public class MascoteMapping
{
    public Mapper mapper { get; set; }
    public MascoteMapping()
    {
        MapperConfiguration config = new(cfg => cfg.CreateMap<Pokemon, Mascote>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Altura, opt => opt.MapFrom(src => src.height))
            .ForMember(dest => dest.Peso, opt => opt.MapFrom(src => src.weight))
            .ForMember(dest => dest.Habilidades, opt => opt.MapFrom(src => src.abilities)));

        mapper = new(config);
    }
}
