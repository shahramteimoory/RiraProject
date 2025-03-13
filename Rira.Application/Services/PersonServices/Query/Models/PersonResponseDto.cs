namespace Rira.Application.Services.PersonServices.Query.Models
{
    public record PersonResponseDto
    {
        public long Id { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string NationalCode { get; set; }
        public  string DateOfBirth { get; set; }
        public string RegisterDate { get; set; }
    }
}
