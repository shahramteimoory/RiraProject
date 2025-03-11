namespace Rira.Domain.Entities
{
    public record Person : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string NationalCode { get; set; }
        public required DateTime DateOfBirth { get; set; }

    }
}
