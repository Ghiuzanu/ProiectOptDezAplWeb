using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProiectOptDezAplWeb.Models;

namespace ProiectOptDezAplWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        public static List<Materials> materials = new List<Materials>
        {
            new Materials{ Id = 1, MaterialName = "Cable4x0.75", Price = 3.00, Amount = 2000, Type = "meters"},
            new Materials{ Id = 2, MaterialName = "Cable4x1.5", Price = 5.00, Amount = 500, Type = "meters"},
            new Materials{ Id = 3, MaterialName = "ZipTies", Price = 21.00, Amount = 10, Type = "100 pieces each"},
            new Materials{ Id = 4, MaterialName = "Cement", Price = 27.49, Amount = 20, Type = "40kg each"},
            new Materials{ Id = 5, MaterialName = "Tube", Price = 5.10, Amount = 50, Type = "3m each"}
        };

        // endpoint
        // Get
        [HttpGet]
        public List<Materials> Getmaterials()
        {
            return materials;
        }

        // Create
        [HttpPost]
        public List<Materials> Add(Materials material)
        {
            material.Id = materials.Count() + 1;
            materials.Add(material);
            return materials;
        }

        // Delete
        [HttpDelete]
        public List<Materials> Delete(Materials material)
        {
            var materialIndex = materials.FindIndex(m => m.Id == material.Id);

            materials.RemoveAt(materialIndex);

            return materials;
        }

        // Update
        [HttpPatch]
        public IActionResult Patch([FromQuery] int id, [FromBody] JsonPatchDocument<Materials> material)
        {
            if(material != null) 
            {
                var materialToUpdate = materials.FirstOrDefault(m => m.Id.Equals(id));
                material.ApplyTo(materialToUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return Ok(materials);
            }
            return BadRequest("Material doesn't exist");
        }
        
    }
}
