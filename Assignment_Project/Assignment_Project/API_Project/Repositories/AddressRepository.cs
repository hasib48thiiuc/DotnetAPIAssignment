using API_Project.Domain.Models;
using API_Project.Domain;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Repositories
{
    public class AddressRepository : IAddressRepository
    {

        private ProjectDbContext _db;
        public AddressRepository(ProjectDbContext ctx)
        {
            _db = ctx;
        }
        public void Add(Student item)
        {

            _db.Database.ExecuteSqlRaw("EXEC dbo.InsertAddress @p0, @p1", item.Name, item.StudentClassId);

        }

        public void Delete(int id)
        {

            _db.Database.ExecuteSqlRaw("EXEC dbo.DeleteStudent @p0", id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _db.Addresses.FromSqlRaw("EXEC dbo.GetAllAddresses").ToList();
        }

        public IEnumerable<Address> GetAllById()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, string name, string city)
        {
            _db.Database.ExecuteSqlRaw("EXEC dbo.UpdateStudent @p0, @p1, @p2", id, name, city);
        }


    }
}
