using BusinessObjecst;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO : ICustomerRepository
    {
        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public Customer GetCustomerById(int id) {
            Customer customer = null;
            try
            {
                using var db = new FuminiHotelManagementContext();
                List<Customer> list = db.Customers.ToList();
                foreach (Customer cus in list) {
                    if (id == cus.CustomerId) { customer = cus; }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        public void AddCustomer(Customer customer) { }
        public void UpdateCustomer(Customer customer) { }
        public void DeleteCustomer(int id) { }

        public Customer Login(string email, string pass)
        {
            Customer cus = new Customer();
            try
            {
                using var db = new FuminiHotelManagementContext();
                List<Customer> list = db.Customers.ToList();
                foreach(Customer cu in list)
                {
                    {
                    if (cu.EmailAddress.Equals(email) && cu.Password.Equals(pass))
                        return cu;
                    }
                }
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
            return cus;
        }
    }
}
