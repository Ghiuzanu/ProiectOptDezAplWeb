using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProiectOptDezAplWeb.Models;

namespace ProiectOptDezAplWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        public static List<Worker> workers = new List<Worker>
        {
            new Worker{ Id = 1, Name = "Edward", Surname = "Ghiuzan", SalaryNET = 4500, Age = 22, Experience = 2},
            new Worker{ Id = 2, Name = "Alin", Surname = "Talmaciu", SalaryNET = 7500, Age = 24, Experience = 4},
            new Worker{ Id = 3, Name = "Eduard", Surname = "Benchea", SalaryNET = 6000, Age = 24, Experience = 3},
            new Worker{ Id = 4, Name = "Marinel", Surname = "Gheorghita", SalaryNET = 8000, Age = 50, Experience = 4},
            new Worker{ Id = 5, Name = "Nicolae", Surname = "Gheorghita", SalaryNET = 9000, Age = 45, Experience = 5},
        };

        // endpoint
        // Get
        [HttpGet]
        public List<Worker> GetWorkers() 
        {
            return workers;
        }

        // Create
        [HttpPost]
        public List<Worker> Add(Worker worker)
        {
            worker.Id = workers.Count() + 1;
            workers.Add(worker);
            return workers;
        }

        // Delete
        [HttpDelete] 
        public List<Worker> Delete(Worker worker) 
        {
            var workerIndex = workers.FindIndex(w => w.Id == worker.Id);

            workers.RemoveAt(workerIndex);

            return workers;
        }

        // Update
        [HttpPatch]
        public IActionResult Patch([FromQuery] int id, [FromBody] JsonPatchDocument<Worker> worker)
        {
            if (worker != null)
            {
                var workerToUpdate = workers.FirstOrDefault(w => w.Id.Equals(id));
                worker.ApplyTo(workerToUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return Ok(workers);
            }
            return BadRequest("Worker doesn't exist");
        }
    }
}
