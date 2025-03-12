using Rira.Application.Services.PersonServices.Command.Models;
using Rira.Common.Dto;

namespace Rira.Application.Services.PersonServices.Command
{
    public interface IPersonManagmentServices
    {
        Task<ApiResult> Insert(InsertPersonRequestDto request);
        Task<ApiResult<UpdatePersonRequestDto>> Update(UpdatePersonRequestDto request);
        Task<ApiResult> SoftDelete(long id);
        Task<ApiResult> HardDelete(long id);
    }
}
