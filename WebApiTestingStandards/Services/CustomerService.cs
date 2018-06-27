using System.Collections.Generic;
using System.Linq;
using WebApiTestingStandards.Models;
using WebApiTestingStandards.Roles;

namespace WebApiTestingStandards.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomer(int? id)
        {
            var customer = GetCustomerData().Customers.FirstOrDefault(c => c.Id == id);
            return customer;
        }

        public CustomerSearchResults GetCustomers()
        {
            return GetCustomerData();
        }

        private CustomerSearchResults GetCustomerData()
        {
            return new CustomerSearchResults
            {
                Customers = new List<Customer>
                {
                    new Customer
                    {
                        Name = "Andrew",
                        Id = 1,
                        Address = "20 Main Street, Sydney, Nsw, 2000",
                        Telephone = "0405444444"
                    },
                    new Customer
                    {
                        Name = "Ananth",
                        Id = 2,
                        Address = "6 West Street, Sydney, Nsw, 2020",
                        Telephone = "0406777000"
                    },
                    new Customer
                    {
                        Name = "James",
                        Id = 3,
                        Address = "71 Smith Street, Sydney, Nsw, 2148",
                        Telephone = "0541666999"
                    },
                    new Customer
                    {
                        Name = "Pallabi",
                        Id = 4,
                        Address = "23 Pleasant Avenue, Sydney, Nsw, 2156",
                        Telephone = "0404555666"
                    }
                }
            };
        }
    }
}