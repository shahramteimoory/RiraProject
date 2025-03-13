using AutoMapper;
using Grpc.Core;
using Rira.Api.Protos;
using Rira.Application.Services.PersonServices.Command.Models;
using Rira.Application.Services.PersonServices.Query.Models;
using Rira.Common.Dto;
using System.Net;

namespace Rira.Api.Mapper
{
    public class PersonMappingProfile: Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<InsertPersonRequest, InsertPersonRequestDto>();
            CreateMap<UpdatePersonRequest, UpdatePersonRequestDto>().ReverseMap();
            CreateMap<PersonResponseDto, PersonResponse>();

            CreateMap<ApiResult, ApiResultProt>()
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(src => src.IsSuccess))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => (int)src.StatusCode))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages));

            CreateMap<FluentValidation.Results.ValidationResult, ApiResultProt>()
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(_ => (int)HttpStatusCode.BadRequest))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Errors.Select(e => e.ErrorMessage)));

            CreateMap<FluentValidation.Results.ValidationResult, ApiResultUpdatePerson>()
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(_ => (int)HttpStatusCode.BadRequest))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Errors.Select(e => e.ErrorMessage)));

            CreateMap<ApiResult<UpdatePersonRequestDto>, ApiResultUpdatePerson>()
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(src => src.IsSuccess))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => (int)src.StatusCode))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            
            CreateMap<ApiResult<List<PersonResponseDto>>, ApiResultGetPeople>()
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(src => src.IsSuccess))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => (int) src.StatusCode))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            CreateMap<ApiResult<PersonResponseDto>, ApiResultGetPerson>()
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(src => src.IsSuccess))
                .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => (int)src.StatusCode))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

        }
    }
}
