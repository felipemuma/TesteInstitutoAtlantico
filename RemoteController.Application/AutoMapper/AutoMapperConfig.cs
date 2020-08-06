using AutoMapper;
using RemoteController.Application.AutoMapper.Mappers;

namespace RemoteController.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new MachineMapper());
                config.AddProfile(new LogMapper());
            });
        }
    }
}
