using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Personels.Repository
{
    public class PersonelRepository : IPersonelRepository
    {
        private readonly appDbContext _context;

        public PersonelRepository(appDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Personel person)
        {
            _context.Personel.Add(person);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? person.Id : 0;
        }

        public async Task<bool> Delete(int Id)
        {
            var person = _context.Personel.FirstOrDefault(p => p.Id == Id);
            if (person is null)
                return false;

            _context.Personel.Remove(person);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> Update(Personel person)
        {
            var personFounded = _context.Personel.FirstOrDefault(p => p.Id == person.Id);

            if (personFounded == null)
                return false;

            _context.Entry(personFounded).State = EntityState.Modified;

            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}

