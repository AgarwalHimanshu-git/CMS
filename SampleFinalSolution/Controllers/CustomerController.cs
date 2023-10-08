using Microsoft.AspNetCore.Mvc;
using SampleFinalSolution.APIClients;
using SampleFinalSolution.Models;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;

namespace SampleFinalSolution.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class CustomerController : Controller
    {
        [HttpGet]
        public IEnumerable<Customer>? Get()
        {
            string apiResponse = MyApIClient.GetData("/Customers").Result;
            List<Customer>? customers = null;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(apiResponse)))
            {
                // Deserialization from JSON
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(List<Customer>));
                customers = (List<Customer>?)deserializer.ReadObject(ms);
            }
            return customers;
        }
        [HttpGet("GetCustomer/{id}")]
        public Customer? Get(string id)
        {
            string apiResponse = MyApIClient.GetData("/Customer/" + id).Result;
            Customer customer = null;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(apiResponse)))
            {
                // Deserialization from JSON
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Customer));
                customer = (Customer)deserializer.ReadObject(ms);
            }
            return customer;
        }

        [HttpPost]
        public void Post(Customer customer)
        {
            Customer cust = new Customer
            {
                Id = customer.Id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Email = customer.Email,
                Phone_Number = customer.Phone_Number,
                Country_Code = customer.Country_Code,
                Gender = customer.Gender,
                Balance = customer.Balance
            };
            var resp = MyApIClient.PostData("/Customer", cust);
        }

        [HttpPost("UpdateCustomer/{id}")]
        public void Post(Customer customer, string id)
        {
            Customer cust = new Customer
            {
                Id = customer.Id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Email = customer.Email,
                Phone_Number = customer.Phone_Number,
                Country_Code = customer.Country_Code,
                Gender = customer.Gender,
                Balance = customer.Balance
            };
            var apiResponse = MyApIClient.PostData("/Customer/" + id, customer);
        }

        [HttpDelete("DeleteCustomer/{id}")]
        //[Route("/UpdateCustomer")]
        public void Delete(string id)
        {
            var apiResponse = MyApIClient.DeleteData("/Customer/" + id);
        }
    }
}


