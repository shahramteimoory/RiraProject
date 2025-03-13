using Microsoft.EntityFrameworkCore;
using Rira.Application.Interfaces.Context;
using Rira.Application.Services.PersonServices.Command.Models;
using Rira.Common.Dto;
using Rira.Common.Utilities;
using Rira.Domain.Entities;

namespace Rira.Application.Services.PersonServices.Command
{
    public class PersonManagmentServices(IDataBaseContext context) : BaseService(context), IPersonManagmentServices
    {
        public async Task<ApiResult> InsertAsync(InsertPersonRequestDto request)
        {

            var isDuplicate = await Table<Person>()
                .AnyAsync(p => p.NationalCode == request.NationalCode);

            if (isDuplicate)
                return ApiResult.Conflict(Alert.Public.Duplicate.GetDescription());

            Person person = new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                NationalCode = request.NationalCode,
                DateOfBirth =PersianDate.ToGregorianDate(request.DateOfBirth)
            };
            await InsertAsync(person);
            await Save();

            return ApiResult.Created(Alert.GetInsertAlert(Alert.EnumEntity.Person));
        }

        public async Task<ApiResult<UpdatePersonRequestDto>> UpdateAsync(UpdatePersonRequestDto request)
        {
            var person = await GetById<Person>(request.Id);

            if (person is null)
                return ApiResult<UpdatePersonRequestDto>.NotFound();

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.NationalCode = request.NationalCode;
            person.DateOfBirth = PersianDate.ToGregorianDate(request.DateOfBirth);
            person.UpdatedAt = DateTime.Now;

            Update(person);
            await Save();

            return ApiResult<UpdatePersonRequestDto>.Success(request);
        }

        public async Task<ApiResult> SoftDeleteAsync(long id)
        {
            var person = await GetById<Person>(id);

            if (person is null)
                return ApiResult.NotFound();

            person.IsDeleted = true;
            person.DeletedAt = DateTime.Now;

            Update(person);
            await Save();

            return ApiResult.Success();
        }

        public async Task<ApiResult> HardDeleteAsync(long id)
        {
            var person = await GetById<Person>(id);

            if (person is null)
                return ApiResult.NotFound();

            Delete(person);
            await Save();

            return ApiResult.Success();
        }
    }
}
