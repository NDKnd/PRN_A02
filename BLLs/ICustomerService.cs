using BusinessObjecst;

namespace BLLs
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        Customer Login(string email, string pass);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}