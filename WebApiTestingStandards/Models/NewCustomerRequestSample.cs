namespace WebApiTestingStandards.Models
{
    public class NewCustomerRequestSample
    {
        public object GetExamples()
        {
            return new Customer
            {
                Name = "SampleName"
            };
        }
    }
}