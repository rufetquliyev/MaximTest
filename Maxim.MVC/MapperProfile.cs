using AutoMapper;
using Maxim.Business.ViewModels.Feature;
using Maxim.Business.ViewModels.User;
using Maxim.Core.Entities;

namespace Maxim.MVC
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateFeatureVm, Feature>().ReverseMap();
            CreateMap<UpdateFeatureVm, Feature>().ReverseMap();
            CreateMap<LoginUserVm, AppUser>().ReverseMap();
            CreateMap<RegisterUserVm, AppUser>().ReverseMap();
        }
    }
}
