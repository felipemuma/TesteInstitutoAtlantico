using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Models;

namespace RemoteController.Application.Interfaces
{
    public interface IMachineService : IDisposable
    {
        void Add(MachineViewModel machineViewModel);
        IEnumerable<MachineViewModel> GetAll();
        MachineViewModel GetById(Guid id);
        Task<MachineViewModel> GetByIdAsync(Guid id);
        void Update(MachineViewModel machineViewModel);
        void Remove(Guid id);
        bool Any(Expression<Func<Machine, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<Machine, bool>> predicate);
    }
}
