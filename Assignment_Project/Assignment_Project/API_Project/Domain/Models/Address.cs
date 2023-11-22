namespace API_Project.Domain.Models
{
    public class Address
    {

        public int AddressId { get; set; }
        public string City { get; set; }

        public int StudentId { get; set; }

        
        public Student Student { get; set; }

    }
}
