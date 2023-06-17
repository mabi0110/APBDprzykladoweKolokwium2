using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.DTOs;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public AnimalsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        [Route("{animalID}")]
        public async Task<IActionResult> GetAnimalData(int animalID)
        {
            if (!await _dbService.DoesAnimalExist(animalID))
                return NotFound($"Owner with given ID - {animalID} doesn't exist");

            var res = await _dbService.GetAnimalData(animalID);
            return Ok(new AnimalDTO
            {
                ID = res.ID,
                Name = res.Name,
                AnimalClass = res.AnimalClass.Name,
                AdmissionDate = res.AdmissionDate,
                Owner = new AnimalOwnerDTO
                {
                    ID = res.Owner.ID,
                    FirstName = res.Owner.FirstName,
                    LastName = res.Owner.LastName,
                },
                Procedures = res.ProcedureAnimals.Select(e => new AnimalProcedureDTO
                {
                    Name = e.Procedure.Name,
                    Date = e.Date
                }).ToList()
            });
        }

    }
}
