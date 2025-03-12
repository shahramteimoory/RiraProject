using Rira.Application.Interfaces.Context;
using Rira.Application.Interfaces.Facade;
using Rira.Application.Services.PersonServices.Command;
using Rira.Application.Services.PersonServices.Command.Models;
using Rira.Application.Services.PersonServices.Command.Validator;

namespace Rira.Application.Services.PersonServices.Facade
{
    public class PersonFacade(IDataBaseContext context) : IPersonFacade
    {
        public IPersonManagmentServices PersonCommands =>
            new PersonManagmentServices(context);

        public PersonValidator<PersonRequestDtoBase> CommandsValidator =>
            new PersonValidator<PersonRequestDtoBase>();
    }
}
