using Microsoft.EntityFrameworkCore;
using Rira.Application.Interfaces.Context;
using Rira.Application.Services.PersonServices.Query.Models;
using Rira.Common.Dto;
using Rira.Common.Utilities;
using Rira.Domain.Entities;

namespace Rira.Application.Services.PersonServices.Query
{
    public class GetPersonManagmentServices(IDataBaseContext context) : BaseService(context), IGetPersonManagmentServices
    {
        public async Task<ApiResult<PersonResponseDto>> GetAsync(long id)
        {
            var person = await GetByIdAsync<Person>(id);
            if (person is null)
                return ApiResult<PersonResponseDto>.NotFound();

            PersonResponseDto result = new PersonResponseDto()
            {
                DateOfBirth = PersianDate.ToShamsiDate(person.DateOfBirth),
                FirstName = person.FirstName,
                LastName = person.LastName,
                Id = person.Id,
                NationalCode = person.NationalCode,
                RegisterDate = PersianDate.LongStringDateTime(person.CreatedAt)
            };

            return ApiResult<PersonResponseDto>.Success(result);
        }

        public async Task<ApiResult<List<PersonResponseDto>>> GetAsync()
        {
            var people = await Table<Person>().Select(s => new PersonResponseDto
            {
                DateOfBirth = PersianDate.ToShamsiDate(s.DateOfBirth),
                FirstName = s.FirstName,
                LastName = s.LastName,
                Id = s.Id,
                NationalCode = s.NationalCode,
                RegisterDate = PersianDate.LongStringDateTime(s.CreatedAt)
            }).ToListAsync();

            return ApiResult<List<PersonResponseDto>>.Success(people);
        }
    }
}
