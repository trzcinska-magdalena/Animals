using Animals.Data;
using Animals.Models;
using Animals.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Animals.Service
{
    public interface IAnimalsService
    {
        Task<IEnumerable<AnimalWithAdditionalDataGET>> GetAnimal(int id);
        Task<bool> IsAnimalExist(int id);
        Task<bool> IsOwnerExist(int id);
        Task<bool> IsProcedureExist(int id);
        Task AddProceduresToAnimal(IEnumerable<ProcedureAnimal> procedureAnimals);
        Task AddAnimal(Animal animal);
        Task<AnimalClass?> GetAnimalClassByName(string name);
    }

    public class AnimalsService : IAnimalsService
    {
        private readonly AnimalsContext _context;

        public AnimalsService(AnimalsContext context)
        {
            _context = context;
        }

        public async Task AddAnimal(Animal animal)
        {
            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task AddProceduresToAnimal(IEnumerable<ProcedureAnimal> procedureAnimals)
        {
            await _context.ProcedureAnimal.AddRangeAsync(procedureAnimals);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<AnimalWithAdditionalDataGET>> GetAnimal(int id)
        {
            return await _context.Animals.Include(e => e.Owner)
                                         .Include(e => e.ProcedureAnimals)
                                         .ThenInclude(e => e.Procedure)
                                         .Select(e => new AnimalWithAdditionalDataGET
                                         {
                                             Id = e.ID,
                                             Name = e.Name,
                                             AnimalClass = e.AnimalClass.Name,
                                             AdmissionDate = e.AdmissionDate,
                                             Owners = new OwnerGET { ID = e.Owner.ID, FirstName = e.Owner.FirstName, LastName = e.Owner.LastName },
                                             Procedures = e.ProcedureAnimals.Select(e => new ProcedureGET { Name = e.Procedure.Name, Date = e.Date}).ToList()
                                         }).Where(e => e.Id == id)
                                         .ToListAsync();
        }

        public async Task<AnimalClass?> GetAnimalClassByName(string name)
        {
            return await _context.AnimalClass.Where(e => e.Name == name).FirstOrDefaultAsync();
        }

        public async Task<bool> IsAnimalExist(int id)
        {
            return await _context.Animals.Where(e => e.ID == id).CountAsync() > 0;
        }

        public async Task<bool> IsOwnerExist(int id)
        {
            return await _context.Owner.Where(e => e.ID == id).CountAsync() > 0;

        }

        public async Task<bool> IsProcedureExist(int id)
        {
            return await _context.Procedure.Where(e => e.ID == id).CountAsync() > 0;

        }
    }
}
