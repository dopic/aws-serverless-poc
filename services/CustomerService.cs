using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        Task<Customer> GetAsync(int id);
        Task AddAsync(Customer customer);
    }

    public class CustomerService : ICustomerService
    {
        private List<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>
            {
                new Customer{Id=2, Name= "Douglas"}
            };
        }

        public Task<Customer> GetAsync(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(customer);
        }

        public Task AddAsync(Customer customer) 
        { 
            _customers.Add(customer);
            return Task.CompletedTask;
        }

    }
}