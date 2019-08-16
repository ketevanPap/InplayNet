using System;
using System.Threading.Tasks;

namespace Inplaynet.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get; }

        Task<int> SaveChangesAsync();
    }
}
