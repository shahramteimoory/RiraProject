using AutoMapper;
using Grpc.Core;
using Rira.Api.Protos;
using Rira.Application.Interfaces.Facade;
using Rira.Application.Services.PersonServices.Command.Models;

namespace Rira.Api.GRPC
{
    public class PeopleService(IPersonFacade personFacade, IMapper mapper) : PersonService.PersonServiceBase
    {
        public override async Task<ApiResultProt> InsertPersonAsync(InsertPersonRequest request, ServerCallContext context)
        {
            var insertPersonRequestDto = mapper.Map<InsertPersonRequestDto>(request);

            var validationResult = await personFacade.CommandsValidator.ValidateAsync(insertPersonRequestDto);
            if (!validationResult.IsValid)
                return mapper.Map<ApiResultProt>(validationResult);

            var result = await personFacade.PersonCommands.InsertAsync(insertPersonRequestDto);

            return mapper.Map<ApiResultProt>(result);
        }

        public override async Task<ApiResultUpdatePerson> UpdatePersonAsync(UpdatePersonRequest request, ServerCallContext context)
        {
            var updatePersonRequestDto = mapper.Map<UpdatePersonRequestDto>(request);

            var validationResult = await personFacade.CommandsValidator.ValidateAsync(updatePersonRequestDto);
            if (!validationResult.IsValid)
                return mapper.Map<ApiResultUpdatePerson>(validationResult);

            var result = await personFacade.PersonCommands.UpdateAsync(updatePersonRequestDto);

            return mapper.Map<ApiResultUpdatePerson>(result);
        }

        public override async Task<ApiResultProt> SoftDeleteAsync(IdRequest request, ServerCallContext context)
        {
            var result = await personFacade.PersonCommands.SoftDeleteAsync(request.Id);
            return mapper.Map<ApiResultProt>(result);
        }

        public override async Task<ApiResultProt> HardDeleteAsync(IdRequest request, ServerCallContext context)
        {
            var result = await personFacade.PersonCommands.HardDeleteAsync(request.Id);
            return mapper.Map<ApiResultProt>(result);
        }

        public override async Task<ApiResultGetPeople> GetAsync(EmptyRequest request, ServerCallContext context)
        {
            var result = await personFacade.PersonQuerys.GetAsync();
            return mapper.Map<ApiResultGetPeople>(result);
        }

        public override async Task<ApiResultGetPerson> GetPersonAsync(IdRequest request, ServerCallContext context)
        {
            var result = await personFacade.PersonQuerys.GetAsync(request.Id);
            return mapper.Map<ApiResultGetPerson>(result);
        }
    }
}
