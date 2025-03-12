namespace Rira.Application.Services.PersonServices.Command.Models
{
    public record UpdatePersonRequestDto: PersonRequestDtoBase
    {
        public required long Id { get; set; }
    }
}
