using System.ComponentModel.DataAnnotations;

namespace WebApiTestingStandards.Models
{
    public class NewCustomerRequest
    {
        [Required] public string Name { get; set; }
        [Required] public string Address { get; set; }
        public string Telephone { get; set; }
    }
}