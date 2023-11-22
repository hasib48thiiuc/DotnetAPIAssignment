using API_Project.Domain.Models;
using API_Project.Domain;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Repositories
{
    public class StudentGradeRepository : IStudentGradeRepository
    {

        private ProjectDbContext _db;
        public StudentGradeRepository(ProjectDbContext ctx)
        {
            _db = ctx;
        }
        public void Add(StudentClass item)
        {
            

            _db.Database.ExecuteSqlRaw("EXEC dbo.InsertStudentClass2 @p0 ",item.Class);

        }

        public void Delete(int id)
        {

            _db.Database.ExecuteSqlRaw("EXEC dbo.DeleteStudentClass @p0", id);
        }

        public IEnumerable<StudentClass> GetAll()
        {
            return _db.StudentClasses.FromSqlRaw("EXEC dbo.GetAllStudentClasses").ToList();

        }

        public StudentClass GetById(int id)
        {
            return _db.StudentClasses.FromSqlRaw("EXEC dbo.GetStudentClassById @p0", id).AsEnumerable().FirstOrDefault();
        }


        public void Update(int id,string name)
        {
            _db.Database.ExecuteSqlRaw("EXEC dbo.UpdateStudentClass @p0, @p1", id, name);
        }
}
}
