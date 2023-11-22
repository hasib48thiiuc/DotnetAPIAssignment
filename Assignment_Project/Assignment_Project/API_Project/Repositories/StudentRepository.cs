using API_Project.DataTransferObjects;
using API_Project.Domain;
using API_Project.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace API_Project.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private ProjectDbContext _db;
        public StudentRepository(ProjectDbContext ctx)
        {
            _db = ctx;
        }
        public void Add(Student item)
        {
            _db.Database.ExecuteSqlRaw("EXEC dbo.InsertStudent @p0, @p1, @p2",
                item.Name , item.StudentClassId, item.Address.City);
            /*
                        @Id INT,
            @Name NVARCHAR(100),
                @StudentClassId INT,
                @AddressCity NVARCHAR(100),
                @StudentId INT OUTPUT,
                @AddressId INT OUTPUT*/
        }

        public void DeleteStudent(int id)
        {

            _db.Database.ExecuteSqlRaw("EXEC dbo.DeleteStudent @p0", id);
        }

        public IEnumerable<Student> GetAllStudent()
        {

            var studentsWithDetails = _db.Students
    .Include(s => s.StudentClass)
    .Include(s => s.Address)
    .ToList();

            return studentsWithDetails;
            /*var studentsWithDetails = _db.Students
                 .FromSqlRaw("EXEC GetStudentsWithDetails9")
                 .ToList();*/

            return studentsWithDetails;
        }

        public Student GetStudentById(int id)
        {
            var result = _db.Students.Where(x => x.Id == id).Include(s => s.StudentClass)
    .Include(s => s.Address).FirstOrDefault();
    
            return result;
         
           
        }


        public void UpdateStudent(Student std)
        {
            Console.WriteLine(std);
            //_db.Database.ExecuteSqlRaw("EXEC UpdateStudentAndAddress @p0, @p1, @p2, @p3", std.Id, std.Name, std.StudentClassId, std.Address.City);
            //_db.Database.ExecuteSqlRaw("EXEC UpdateStudentAndAddressNew @p0, @p1, @p2, @p3", std.Id, std.Name, std.StudentClassId, std.Address.City);
            _db.Students.Update(std);
            _db.SaveChanges();
        }


    }
}
