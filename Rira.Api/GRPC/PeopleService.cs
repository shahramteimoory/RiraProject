using AutoMapper;
using Grpc.Core;
using Rira.Api.Protos;
using Rira.Application.Interfaces.Facade;
using Rira.Application.Services.PersonServices.Command.Models;
using Rira.Common.Utilities;
using System.Net;

namespace Rira.Api.GRPC
{
    public class PeopleService(IPersonFacade personFacade, IMapper mapper,Logger<PeopleService> logger) : PersonService.PersonServiceBase
    {
        public override async Task<ApiResultProt> InsertPersonAsync(InsertPersonRequest request, ServerCallContext context)
        {
            try
            {
                var insertPersonRequestDto = mapper.Map<InsertPersonRequestDto>(request);

                var validationResult = await personFacade.CommandsValidator.ValidateAsync(insertPersonRequestDto);
                if (!validationResult.IsValid)
                    return mapper.Map<ApiResultProt>(validationResult);

                var result = await personFacade.PersonCommands.InsertAsync(insertPersonRequestDto);

                return mapper.Map<ApiResultProt>(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"PeopleService ,InsertPersonAsync,{ex.Message},{ex.StackTrace} ");
                return new ApiResultProt
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Messages = { Alert.Public.InternalServerError.GetDescription() },
                };
            }
        }

        public override async Task<ApiResultUpdatePerson> UpdatePersonAsync(UpdatePersonRequest request, ServerCallContext context)
        {
            try
            {
                var updatePersonRequestDto = mapper.Map<UpdatePersonRequestDto>(request);

                var validationResult = await personFacade.CommandsValidator.ValidateAsync(updatePersonRequestDto);
                if (!validationResult.IsValid)
                    return mapper.Map<ApiResultUpdatePerson>(validationResult);

                var result = await personFacade.PersonCommands.UpdateAsync(updatePersonRequestDto);

                return mapper.Map<ApiResultUpdatePerson>(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"PeopleService ,UpdatePersonAsync,{ex.Message},{ex.StackTrace} ");
                return new ApiResultUpdatePerson
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Messages = { Alert.Public.InternalServerError.GetDescription() },
                };
            }
        }

        public override async Task<ApiResultProt> SoftDeleteAsync(IdRequest request, ServerCallContext context)
        {
            try
            {
                var result = await personFacade.PersonCommands.SoftDeleteAsync(request.Id);
                return mapper.Map<ApiResultProt>(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"PeopleService ,SoftDeleteAsync,{ex.Message},{ex.StackTrace} ");
                return new ApiResultProt
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Messages = { Alert.Public.InternalServerError.GetDescription() },
                };
            }
        }

        public override async Task<ApiResultProt> HardDeleteAsync(IdRequest request, ServerCallContext context)
        {
            try
            {
                var result = await personFacade.PersonCommands.HardDeleteAsync(request.Id);
                return mapper.Map<ApiResultProt>(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"PeopleService ,HardDeleteAsync,{ex.Message},{ex.StackTrace} ");
                return new ApiResultProt
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Messages = { Alert.Public.InternalServerError.GetDescription() },
                };
            }
        }

        public override async Task<ApiResultGetPeople> GetAsync(EmptyRequest request, ServerCallContext context)
        {
            try
            {
                var result = await personFacade.PersonQuerys.GetAsync();
                return mapper.Map<ApiResultGetPeople>(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"PeopleService ,GetAsync,{ex.Message},{ex.StackTrace} ");
                return new ApiResultGetPeople
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Messages = { Alert.Public.InternalServerError.GetDescription() },
                };
            }
        }

        public override async Task<ApiResultGetPerson> GetPersonAsync(IdRequest request, ServerCallContext context)
        {
            try
            {
                var result = await personFacade.PersonQuerys.GetAsync(request.Id);
                return mapper.Map<ApiResultGetPerson>(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"PeopleService ,GetPersonAsync,{ex.Message},{ex.StackTrace} ");
                return new ApiResultGetPerson
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Messages = { Alert.Public.InternalServerError.GetDescription() },
                };
            }
        }
    }
}
