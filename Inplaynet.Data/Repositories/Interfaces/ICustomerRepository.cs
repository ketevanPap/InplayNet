using Inplaynet.Model.DbModels;
using System.Threading.Tasks;

namespace Inplaynet.Data.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> Register(Customer customer, string password);

        Task<bool> PrivateIDExists(ulong privateID);

        Task<bool> EmailExists(string email, int id = 0);

        Task<bool> MobileExists(string email, int id = 0);
    }
}
