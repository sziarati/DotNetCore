using Core.Entities;

namespace Core.Interfaces
{
    public interface IPersonelRepository
    {
        public Task<int> Add(Personel person);
        public Task<bool> Update(Personel person);
        public Task<bool> Delete(int Id);
    }
}