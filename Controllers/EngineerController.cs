using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProiectOptDezAplWeb.Models;

namespace ProiectOptDezAplWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineerController : ControllerBase
    {
        public static List<Engineer> engineers = new List<Engineer>
        {
            new Engineer{ Id = 1, Name = "Dragos", Surname = "Giurgila", SalaryNET = 10000, Age = 40, Degree = true},
            new Engineer{ Id = 2, Name = "Sergiu", Surname = "Dumea", SalaryNET = 8000, Age = 21, Degree = false}
        };

        // endpoint
        // Get
        [HttpGet]
        public List<Engineer> GetEngineers()
        {
            return engineers;
        }

        // Create
        [HttpPost]
        public List<Engineer> Add(Engineer engineer)
        {
            engineer.Id = engineers.Count() + 1;
            engineers.Add(engineer);
            return engineers;
        }

        // Delete
        [HttpDelete]
        public List<Engineer> Delete(Engineer engineer)
        {
            var engineerIndex = engineers.FindIndex(e => e.Id == engineer.Id);
            engineers.RemoveAt(engineerIndex);
            return engineers;
        }

        // Update
        [HttpPatch]
        public IActionResult Patch([FromQuery] int id, [FromBody] JsonPatchDocument<Engineer> engineer)
        {
            if (engineer != null)
            {
                var engineerToUpdate = engineers.FirstOrDefault(e => e.Id.Equals(id));
                engineer.ApplyTo(engineerToUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return Ok(engineers);
            }
            return BadRequest("Engineer doesn't exist");
        }
    }
}
