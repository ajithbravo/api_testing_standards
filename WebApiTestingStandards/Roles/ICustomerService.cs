using WebApiTestingStandards.Models;

namespace WebApiTestingStandards.Roles
{
    public interface ICustomerService
    {
        CustomerSearchResults GetCustomers();
        Customer GetCustomer(int? id);
    }
}