using AutoMapper;
using Inplaynet.Data.Repositories.Interfaces;
using Inplaynet.Data.Security;
using Inplaynet.Model.DbModels;
using Inplaynet.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inplaynet.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Private Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HashingPassword _hashing;
        #endregion

        #region Constructor
        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper, HashingPassword hashing)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hashing = hashing;
        }
        #endregion

        #region Methods
        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            customerDto.Email = customerDto.Email.ToLower();

            if (await _unitOfWork.Customer.PrivateIDExists(customerDto.PrivateID))
                return BadRequest("PrivateID already exists");

            if (await _unitOfWork.Customer.EmailExists(customerDto.Email))
                return BadRequest("Email already exists");

            if (await _unitOfWork.Customer.MobileExists(customerDto.Mobile))
                return BadRequest("Mobile already exists");

            var customer = _mapper.Map<Customer>(customerDto);

            await _unitOfWork.Customer.
                Register(customer, customerDto.Password);

            return StatusCode(201);
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _unitOfWork.Customer.
                            GetAllAsync();

            if (!customers.Any())
                return NoContent();

            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return Ok(customersDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _unitOfWork.Customer.EmailExists(updateCustomerDto.Email, updateCustomerDto.ID))
                return BadRequest("Email already exists");

            if (await _unitOfWork.Customer.MobileExists(updateCustomerDto.Mobile, updateCustomerDto.ID))
                return BadRequest("Mobile already exists");

            var customerInDb = await _unitOfWork.Customer.
                GetAsync(updateCustomerDto.ID);

            var customer = _mapper.Map<Customer>(updateCustomerDto);

            customer.DateOfBirth = customerInDb.DateOfBirth;
            customer.Resident = customerInDb.Resident;
            customer.PrivateID = customerInDb.PrivateID;
            customer.RegistrationDate = customerInDb.RegistrationDate;
            customer.RegistrationIP = customerInDb.RegistrationIP;

            _hashing.CreatePasswordHash(updateCustomerDto.Password, out byte[] passworHash, out byte[] passwordSalt);
            customer.PasswordHash = passworHash;
            customer.PasswordSalt = passwordSalt;

            bool result = await _unitOfWork.Customer.
                UpdateAsync(customer, updateCustomerDto.ID);

            if (!result)
                return NoContent();

            return Ok(customer);
        }
        #endregion
    }

}
