using BusinessObjecst;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLs
{
    public class CustomerService : ICustomerService
    {

        ICustomerRepository cusRepos;

        public CustomerService() 
        {
            cusRepos = new CustomerDAO();
        }
        
        public void AddCustomer(Customer customer)
            => cusRepos.AddCustomer(customer);

        public void DeleteCustomer(int id)
            => cusRepos.DeleteCustomer(id);

        public Customer GetCustomerById(int id)
            => cusRepos.GetCustomerById(id);

        public List<Customer> GetCustomers()
            => cusRepos.GetCustomers();

        public Customer Login(string email, string pass)
            => cusRepos.Login(email, pass);

        public void UpdateCustomer(Customer customer)
            => cusRepos.UpdateCustomer(customer);
    }
}
