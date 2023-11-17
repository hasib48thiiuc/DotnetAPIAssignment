using API_Project.DataTransferObjects;
using API_Project.Domain.Models;

namespace API_Project.Repositories
{
    public interface IStudentGradeRepository
    {
        void Add(StudentClass item);
        void Delete(int id);
        IEnumerable<StudentClass> GetAll();
        StudentClass GetById(int id);
        public void Update(int id, string name);
    }
}