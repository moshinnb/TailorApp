using Server.Domain.Entities;

namespace Server.Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer, CancellationToken ct);
        Task DeleteCustomerAsync(Guid id);
        IQueryable<Customer> GetAllCustomers();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<Customer> UpateCustomerDetails(Guid id, Customer customer);
    }
}