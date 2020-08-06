using RemoteController.Data.Context;
using RemoteController.Domain.Interfaces;

namespace RemoteController.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RemoteControllerContext _context;

        public UnitOfWork(RemoteControllerContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
