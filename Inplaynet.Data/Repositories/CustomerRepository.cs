using Inplaynet.Data.Repositories.Interfaces;
using Inplaynet.Data.Security;
using Inplaynet.Model.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Inplaynet.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        #region Private Fields

        private readonly HashingPassword _hashing;
        private InplaynetDbContext _appContext => (InplaynetDbContext)_context;

        #endregion

        #region Constructor
        public CustomerRepository(DbContext context) : base(context)
        {
            _hashing = new HashingPassword();
        }
        #endregion

        #region Methods

        public async Task<Customer> Register(Customer customer, string password)
        {
            _hashing.CreatePasswordHash(password, out byte[] passworHash, out byte[] passwordSalt);

            customer.PasswordHash = passworHash;
            customer.PasswordSalt = passwordSalt;

            await _appContext.Customers.AddAsync(customer);
            await _appContext.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> PrivateIDExists(ulong privateID)
        {
            if (await _appContext.Customers.AnyAsync(x => x.PrivateID == privateID))
                return true;
            return false;
        }

        public async Task<bool> EmailExists(string email, int id = 0)
        {
            if (await _appContext.Customers.AnyAsync(x => x.Email == email && x.ID != id))
                return true;
            return false;
        }

        public async Task<bool> MobileExists(string mobile, int id = 0)
        {
            if (await _appContext.Customers.AnyAsync(x => x.Mobile == mobile && x.ID != id))
                return true;
            return false;
        }
        #endregion
    }
}
