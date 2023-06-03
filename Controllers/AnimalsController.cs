using Animals.Models;
using Animals.Models.DTOs;
using Animals.Service;
using Microsoft.AspNetCore.Mvc;

namespace Animals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsService _dbService;

        public AnimalsController(IAnimalsService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{animalID}")]
        public async Task<IActionResult> GetAnimals(int animalID)
        {
            if (! await _dbService.IsAnimalExist(animalID))
                return NotFound("The animal doesn't exist!");

            var orders = await _dbService.GetAnimal(animalID);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(AnimalPUT animalPUT)
        {
            if (!await _dbService.IsOwnerExist(animalPUT.OwnerID))
                return NotFound("The owner doesn't exist!");

            var animalClass = await _dbService.GetAnimalClassByName(animalPUT.AnimalClass);
            if (animalClass == null)
                return NotFound("The animal class doesn't exist!");

            var animal = new Animal
            {
                Name = animalPUT.Name,
                AdmissionDate = animalPUT.AdmissionDate,
                OwnerID = animalPUT.OwnerID,
                AnimalClass = animalClass
            };


            List<ProcedureAnimal> procedureAnimals = new List<ProcedureAnimal>();
            foreach (var item in animalPUT.Procedures)
            {
                if (!await _dbService.IsProcedureExist(item.ProcedureID))
                    return NotFound("The procedure doesn't exist!");

                procedureAnimals.Add(new ProcedureAnimal
                {
                    ProcedureID = item.ProcedureID,
                    Animal = animal,
                    Date = item.Date
                });
            }
            
            await _dbService.AddAnimal(animal);
            await _dbService.AddProceduresToAnimal(procedureAnimals);

            return Created("api/animals/", "");
        }
    }
}
