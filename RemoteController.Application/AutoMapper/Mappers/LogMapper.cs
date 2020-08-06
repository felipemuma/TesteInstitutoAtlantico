using AutoMapper;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Models;

namespace RemoteController.Application.AutoMapper.Mappers
{
    public class LogMapper : Profile
    {
        public LogMapper()
        {
            CreateMap<Log, LogViewModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<LogViewModel, Log>();
        }
    }
}
