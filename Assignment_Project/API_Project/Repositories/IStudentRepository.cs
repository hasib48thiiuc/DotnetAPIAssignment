using API_Project.DataTransferObjects;
using API_Project.Domain.Models;

namespace API_Project.Repositories
{
    public interface IStudentRepository
    {
        void Add(Student item);
        void DeleteStudent(int id);
        IEnumerable<Student> GetAllStudent();
        Student GetStudentById(int id);
        void UpdateStudent(Student std);
    }
}
