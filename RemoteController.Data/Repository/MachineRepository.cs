using System.Linq;
using RemoteController.Data.Context;
using RemoteController.Domain.Interfaces;
using RemoteController.Domain.Models;

namespace RemoteController.Data.Repository
{
    public class MachineRepository : Repository<Machine>, IMachineRepository
    {
        public MachineRepository(RemoteControllerContext dbContext) : base(dbContext)
        {
        }
    }
}
