using Rira.Application.Services.PersonServices.Command;
using Rira.Application.Services.PersonServices.Command.Models;
using Rira.Application.Services.PersonServices.Command.Validator;
using Rira.Application.Services.PersonServices.Query;

namespace Rira.Application.Interfaces.Facade
{
    public interface IPersonFacade
    {
        IPersonManagmentServices PersonCommands { get; }
        PersonValidator<PersonRequestDtoBase> CommandsValidator { get; }

        IGetPersonManagmentServices PersonQuerys { get; }
    }
}
