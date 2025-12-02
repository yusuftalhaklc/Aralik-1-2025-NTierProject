using AutoMapper;
using Project.Bll.Dtos;
using Project.WebApi.Model.RequestModels;

namespace Project.WebApi.AutoMapper
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();
        }
    }
}
