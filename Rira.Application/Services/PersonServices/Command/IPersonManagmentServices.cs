using Rira.Application.Services.PersonServices.Command.Models;
using Rira.Common.Dto;

namespace Rira.Application.Services.PersonServices.Command
{
    public interface IPersonManagmentServices
    {
        Task<ApiResult> InsertAsync(InsertPersonRequestDto request);
        Task<ApiResult<UpdatePersonRequestDto>> UpdateAsync(UpdatePersonRequestDto request);
        Task<ApiResult> SoftDeleteAsync(long id);
        Task<ApiResult> HardDeleteAsync(long id);
    }
}
