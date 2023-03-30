using AutoMapper;
using GA_Intergado.CR2.App.ServerIntegration.Services;
using GA_Intergado.CR2.Domain.Recipes;
using GA_Intergado.CR2.Domain.Recipes.ValueObjects;
using GA_Intergado.CR2.Domain.Shared.Common;
using GA_Intergado.CR2.Domain.Shared.Users;
using GA_Intergado.CR2.Domain.Users;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using GA_Intergado.CR2.IntegrationService.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GA_Intergado.CR2.IntegrationService
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IIntegrationService, IntegrationService>();

            //services.AddOptions<IIntegrationSettings>().Configure(myOptions =>
            //{
            //    myOptions.HostAdress = "http://15.229.60.60:22603";
            //});

            services.AddAutoMapper(typeof(IntegrationProfile));
            return services;
        }
    }

    public class IntegrationProfile : Profile
    {
        public IntegrationProfile()
        {
            CreateMap<UserAPIVM, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => UserId.CreateUnique()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Senha))
                .ForMember(dest => dest.ModifierUserId, opt => opt.MapFrom(src => UserId.CreateUnique()))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => (UserType)src.TipoUsuario));

            CreateMap<ReceitaCR1VM, Recipe>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => RecipeId.CreateUnique()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.MixTimeMinute, opt => opt.MapFrom(src => Convert.ToInt32(src.mixing_Time)))
                .ForMember(dest => dest.NameAbbreviation, opt => opt.MapFrom(src => src.alpha_code))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.versao))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusType.active))
                .ForMember(dest => dest.ModifierUserId, opt => opt.MapFrom(src => UserId.CreateUnique()));
        }
    }
}