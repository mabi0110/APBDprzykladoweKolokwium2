using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services
{


   
    public interface IDbService
    {
        Task<bool> DoesAnimalExist(int animalID);
        Task<Animal> GetAnimalData(int animalID);

    }





    public class DbService : IDbService
    {
        private readonly DatabaseContext _context;
        public DbService(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<bool> DoesAnimalExist(int animalID)
        {
            return await _context.Animals.AnyAsync(e => e.ID == animalID);
        }

       

        public async Task<Animal> GetAnimalData(int animalID)
        {
            return await _context.Animals
                .Include(e => e.Owner)
                .Include(e => e.AnimalClass)
                .Include(e => e.ProcedureAnimals)
                .ThenInclude(e => e.Procedure)
                .Where(e => e.ID == animalID)
                .FirstAsync();
        }
    }
}
