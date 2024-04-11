using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
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

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateAsync(CreatePersonelDto personel)
        {
            var person = new Entities.Personel()
            {
                CreateDate = DateTime.Now,
                Name = personel.Name,
                Family = personel.Family,
                Email = personel.Email,
            };

            var result = await _personelRepository.Add(person);
            return result > 0 ? Ok(result) : BadRequest("Creation failed.");
        }

        [HttpDelete("Delete/{personelId}")]
        public async Task<IActionResult> DeleteAsync(int personelId)
        {
            var deleteResult = await _personelRepository.Delete(personelId);
            return deleteResult ? Ok() : NotFound("Person Not Found.");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdatePersonelDto person)
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

            var updateResult = await _personelRepository.Update(userPersonel);
            return updateResult ? Ok(): NotFound("Person Not Found.");
        }
    }
}