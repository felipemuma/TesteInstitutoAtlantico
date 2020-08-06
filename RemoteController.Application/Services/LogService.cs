using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RemoteController.Application.Interfaces;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Interfaces;
using RemoteController.Domain.Models;

namespace RemoteController.Application.Services
{
    public class LogService : ILogService
    {
        private readonly IMapper _mapper;
        private readonly ILogRepository _logRepository;

        public LogService(IMapper mapper, ILogRepository logRepository)
        {
            _mapper = mapper;
            _logRepository = logRepository;
        }

        public void Add(LogViewModel logViewModel)
        {
            var log = _mapper.Map<LogViewModel, Log>(logViewModel);
            _logRepository.Add(log);
        }

        public IEnumerable<LogViewModel> GetAll()
        {
            var logs = _mapper.Map<IEnumerable<Log>, IEnumerable<LogViewModel>>(_logRepository.GetAll());
            return logs;
        }

        public LogViewModel GetById(Guid id)
        {
            return _mapper.Map<Log, LogViewModel>(_logRepository.GetById(id));
        }

        public void Update(LogViewModel logViewModel)
        {
            var log = _mapper.Map<LogViewModel, Log>(logViewModel);
            _logRepository.Update(log);
        }

        public void Remove(Guid id)
        {
            _logRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
