using AutoMapper;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Models;

namespace RemoteController.Application.AutoMapper.Mappers
{
    public class MachineMapper : Profile
    {
        public MachineMapper()
        {
            CreateMap<Machine, MachineViewModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<MachineViewModel, Machine>()
                .ForMember(dest => dest.Logs, opt => opt.Ignore());
        }
    }
}

