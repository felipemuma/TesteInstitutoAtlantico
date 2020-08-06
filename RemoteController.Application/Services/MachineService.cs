using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using RemoteController.Application.Interfaces;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Interfaces;
using RemoteController.Domain.Models;

namespace RemoteController.Application.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMapper _mapper;
        private readonly IMachineRepository _machineRepository;

        public MachineService(IMapper mapper, IMachineRepository machineRepository)
        {
            _mapper = mapper;
            _machineRepository = machineRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(MachineViewModel machineViewModel)
        {
            var machine = _mapper.Map<MachineViewModel, Machine>(machineViewModel);
            _machineRepository.Add(machine);
        }

        public IEnumerable<MachineViewModel> GetAll()
        {
            var machines = _mapper.Map<IEnumerable<Machine>, IEnumerable<MachineViewModel>>(_machineRepository.GetAll());
            return machines;
        }

        public MachineViewModel GetById(Guid id)
        {
            return _mapper.Map<MachineViewModel>(_machineRepository.GetById(id));
        }

        public async Task<MachineViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<MachineViewModel>(await _machineRepository.GetByIdAsync(id));
        }

        public void Update(MachineViewModel machineViewModel)
        {
            var machine = _mapper.Map<MachineViewModel, Machine>(machineViewModel);
            _machineRepository.Update(machine);
        }

        public void Remove(Guid id)
        {
            _machineRepository.Remove(id);
        }

        public bool Any(Expression<Func<Machine, bool>> predicate)
        {
            return _machineRepository.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<Machine, bool>> predicate)
        {
            return await _machineRepository.AnyAsync(predicate);
        }
    }
}
