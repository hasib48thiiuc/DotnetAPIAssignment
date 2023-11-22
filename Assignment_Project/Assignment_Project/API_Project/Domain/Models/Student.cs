namespace API_Project.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StudentClassId { get; set; }

        public StudentClass StudentClass { get; set; }
        public Address Address{ get; set; }

    }
}
