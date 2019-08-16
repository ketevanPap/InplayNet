using Inplaynet.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Inplaynet.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly InplaynetDbContext _context;

        ICustomerRepository _customer;

        public UnitOfWork(InplaynetDbContext context)
        {
            _context = context;
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                    _customer = new CustomerRepository(_context);

                return _customer;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
