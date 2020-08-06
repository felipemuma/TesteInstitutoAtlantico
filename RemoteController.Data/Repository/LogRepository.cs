using RemoteController.Data.Context;
using RemoteController.Domain.Interfaces;
using RemoteController.Domain.Models;

namespace RemoteController.Data.Repository
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(RemoteControllerContext dbContext) : base(dbContext)
        {
        }
    }
}
