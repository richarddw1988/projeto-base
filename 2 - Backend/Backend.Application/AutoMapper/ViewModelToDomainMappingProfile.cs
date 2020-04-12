using AutoMapper;
using Backend.App.ViewModel;
using Backend.Domain.Models;

namespace Backend.App.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
          CreateMap<UserModel, UserEntity>();
        }
    }
}
