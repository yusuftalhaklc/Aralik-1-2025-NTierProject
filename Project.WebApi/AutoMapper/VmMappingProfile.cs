using AutoMapper;
using Project.Bll.Dtos;
using Project.WebApi.Model.RequestModels;
using Project.WebApi.Model.ResponseModels;

namespace Project.WebApi.AutoMapper
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();

            CreateMap<CreateProductRequestModel, ProductDto>();
            CreateMap<UpdateProductRequestModel, ProductDto>();
            CreateMap<ProductDto, ProductResponseModel>();

            CreateMap<CreateOrderRequestModel, OrderDto>();
            CreateMap<UpdateOrderRequestModel, OrderDto>();
            CreateMap<OrderDto, OrderResponseModel>();

            CreateMap<CreateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<UpdateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetailResponseModel>();

            CreateMap<CreateAppUserRequestModel, AppUserDto>();
            CreateMap<UpdateAppUserRequestModel, AppUserDto>();
            CreateMap<AppUserDto, AppUserResponseModel>();

            CreateMap<CreateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<UpdateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<AppUserProfileDto, AppUserProfileResponseModel>();
        }
    }
}
