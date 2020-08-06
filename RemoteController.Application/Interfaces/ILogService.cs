using System;
using System.Collections.Generic;
using RemoteController.Application.ViewModels;

namespace RemoteController.Application.Interfaces
{
    public interface ILogService : IDisposable
    {
        void Add(LogViewModel logViewModel);
        IEnumerable<LogViewModel> GetAll();
        LogViewModel GetById(Guid id);
        void Update(LogViewModel logViewModel);
        void Remove(Guid id);
    }
}
