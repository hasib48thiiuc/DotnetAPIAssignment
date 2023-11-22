namespace API_Project.Domain.Models
{
    public class StudentClass
    {
        public int Id { get; set; }
        public string Class { get; set; }

        public List<Student> Students { get; set; }

    }
}
