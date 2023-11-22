using API_Project.Domain.Models;
using API_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressRepository _repo;

        public AddressController(IAddressRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<AddressController>
       /* [HttpGet]
        public IEnumerable<Address> Get()
        {
            return _repo.
        }
*/
        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddressController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
