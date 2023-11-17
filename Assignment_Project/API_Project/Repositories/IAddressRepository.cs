using API_Project.Domain.Models;

namespace API_Project.Repositories
{
    public interface IAddressRepository
    {
        void Add(Student item);
        void Delete(int id);
        IEnumerable<Address> GetAllById();
        void Update(int id, string name, string city);
        public IEnumerable<Address> GetAll();

    }
}