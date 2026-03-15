using Server.Domain.Entities;
using Server.Infrastructure.Data;
using Server.Infrastructure.Interfaces;

namespace Server.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCustomerAsync(Customer customer, CancellationToken ct)
        {
            var existingCustomer = await _context.Customers.FindAsync(new object[] { customer.Name, customer.Phone }, ct);
            if (existingCustomer != null)
            {
                throw new InvalidOperationException("A customer with the same name and phone number already exists.");
            }
            await _context.Customers.AddAsync(customer, ct);
            await _context.SaveChangesAsync(ct);

        }
        public async Task<Customer> UpateCustomerDetails(Guid id, Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }
            existingCustomer.Name = customer.Name;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;
            _context.Customers.Update(existingCustomer);
            await _context.SaveChangesAsync();
            return existingCustomer;
        }
        public async Task DeleteCustomerAsync(Guid id)
        {
            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }
            existingCustomer.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public IQueryable<Customer> GetAllCustomers()
        {
            return _context.Customers;
        }
        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null || customer.IsDeleted)
            {
                throw new KeyNotFoundException("Customer not found.");
            }
            return customer;
        }
    }
}
