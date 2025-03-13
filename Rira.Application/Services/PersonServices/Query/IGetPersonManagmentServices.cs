using Rira.Application.Services.PersonServices.Query.Models;
using Rira.Common.Dto;

namespace Rira.Application.Services.PersonServices.Query
{
    public interface IGetPersonManagmentServices
    {
        Task<ApiResult<PersonResponseDto>> GetAsync(long id);
        Task<ApiResult<List<PersonResponseDto>>> GetAsync();
    }
}
