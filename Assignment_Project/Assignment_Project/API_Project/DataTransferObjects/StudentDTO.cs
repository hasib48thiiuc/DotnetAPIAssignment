using API_Project.Domain.Models;

namespace API_Project.DataTransferObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StudentClassId { get; set; }

        public AddressDTO Address { get; set; }
    }
}
