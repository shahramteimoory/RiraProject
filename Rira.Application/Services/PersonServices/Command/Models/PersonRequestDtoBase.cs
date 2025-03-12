namespace Rira.Application.Services.PersonServices.Command.Models
{
    public abstract record PersonRequestDtoBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
