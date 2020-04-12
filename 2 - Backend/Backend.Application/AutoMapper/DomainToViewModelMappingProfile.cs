using AutoMapper;
using Backend.App.ViewModel;
using Backend.Domain.Models;

namespace Backend.App.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UserEntity, UserModel>();
        }
    }
}
