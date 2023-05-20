using Demo_01_Web_API_Intro.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo_01_Web_API_Intro.Controllers
{
    // URL https://localhost:7235/api/Desserts

    [Route("api/[controller]")]
    [ApiController]
    public class DessertsController : ControllerBase
    {
        // GET: api/Desserts
        [HttpGet]
        public List<Dessert> Get()
        {
            return Dessert.Desserts;
        }

        // GET api/Desserts/5
        [HttpGet("{id}")]
        public Dessert Get(int id)
        {
            Dessert result = Dessert.Desserts.FirstOrDefault(x => x.Id == id);
            return result;
        }

        // POST api/Desserts
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Desserts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Desserts/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Dessert dessertToDelete = Dessert.Desserts.FirstOrDefault(x => x.Id == id);
            return Dessert.Desserts.Remove(dessertToDelete);
        }
    }
}
