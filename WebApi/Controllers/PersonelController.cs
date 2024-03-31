using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities = Core.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelRepository _personelRepository;

        public PersonelController(IPersonelRepository personelRepository)
        {
            _personelRepository = personelRepository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create(Personel personel)
        {
            var person = new Entities.Personel()
            {
                CreateDate = DateTime.Now,
                Name = personel.Name,
                Family = personel.Family,
                Email = personel.Email,
            };

            var result = await _personelRepository.Add(person);
            return result > 0 ? person.Id : 0;
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> Delete(int personelId)
        {
            return await _personelRepository.Delete(personelId);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<bool> Update(Personel person)
        {
            var userPersonel = new Entities.Personel
            {
                Id = person.Id,
                EditDate = DateTime.Now,
                Name = person.Name,
                Family = person.Family,
                Email = person.Email,
                IsArchived = false
            };

            return await _personelRepository.Update(userPersonel);
        }
    }
}