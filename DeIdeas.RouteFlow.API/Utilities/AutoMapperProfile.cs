using AutoMapper;
using DeIdeas.RouteFlow.API.DAL.Models.ModuleUser;
using DeIdeas.RouteFlow.API.DTOs.UsrDTOs;

namespace DeIdeas.RouteFlow.API.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region VISTAS A CONSUMIR LEGACY SYSTEM

            //CreateMap<CXC_V_RepFileDropSBFRE, ReadCXC_V_RepFileDropSBFREDto>();
            //.ForMember(dest => dest.DateFile,
            //opt => opt.MapFrom(src => src.DateFile.ToString("dd/MM/yyyy - hh:mm:ss tt")));


            #endregion

            #region MODULE USER-CONTROL

            #region TypeUser

            CreateMap<USR_TypeUser, ReadTypeUserDto>()
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date.ToString("dd/MM/yyyy - HH:mm:ss")))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            CreateMap<CreateTypeUserDto, USR_TypeUser>()
                .ForMember(d => d.Date, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.Status, o => o.MapFrom(_ => 1));

            CreateMap<ModifyTypeUserDto, USR_TypeUser>();

            CreateMap<ChangeStatusTypeUserDto, USR_TypeUser>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            #endregion

            #region DetTypeUser

            CreateMap<USR_DetTypeUser, ReadDetTypeUserDto>();

            CreateMap<CreateDetTypeUserDto, USR_DetTypeUser>();

            CreateMap<ModifyDetTypeUserDto, USR_DetTypeUser>();

            #endregion

            #region User

            CreateMap<USR_User, ReadUserDto>()
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date.ToString("dd/MM/yyyy - HH:mm:ss")))
                .ForMember(d => d.LastLogin, o => o.MapFrom(s => s.LastLogin.ToString("dd/MM/yyyy - HH:mm:ss")))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            CreateMap<CreateUserDto, USR_User>()
                .ForMember(d => d.Date, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.LastLogin, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.Status, o => o.MapFrom(_ => 1));

            CreateMap<ModifyUserDto, USR_User>();

            CreateMap<ChangeStatusUserDto, USR_User>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            #endregion

            #region Config

            CreateMap<USR_Config, ReadConfigDto>()
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date.ToString("dd/MM/yyyy - HH:mm:ss")));

            CreateMap<CreateConfigDto, USR_Config>()
                .ForMember(d => d.Date, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.Status, o => o.MapFrom(_ => 1));

            CreateMap<ModifyConfigDto, USR_Config>();

            CreateMap<ChangeStatusConfigDto, USR_Config>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            #endregion

            #region Rol

            CreateMap<USR_Rol, ReadRolDto>()
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date.ToString("dd/MM/yyyy - HH:mm:ss")));

            CreateMap<CreateRolDto, USR_Rol>()
                .ForMember(d => d.Date, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.Status, o => o.MapFrom(_ => 1));

            CreateMap<ModifyRolDto, USR_Rol>();

            CreateMap<ChangeStatusRolDto, USR_Rol>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            #endregion

            #region UserRol

            CreateMap<USR_UserRol, ReadUserRolDto>()
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date.ToString("dd/MM/yyyy - HH:mm:ss")))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            CreateMap<CreateUserRolDto, USR_UserRol>()
                .ForMember(d => d.Date, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.Status, o => o.MapFrom(_ => 1));

            CreateMap<ModifyUserRolDto, USR_UserRol>();

            CreateMap<ChangeStatusUserRolDto, USR_UserRol>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            #endregion

            #region Control

            CreateMap<USR_Control, ReadControlDto>()
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date.ToString("dd/MM/yyyy - HH:mm:ss")))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            CreateMap<CreateControlDto, USR_Control>()
                .ForMember(d => d.Date, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.Status, o => o.MapFrom(_ => 1));

            CreateMap<ModifyControlDto, USR_Control>();

            CreateMap<ChangeStatusControlDto, USR_Control>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            #endregion

            #region ControlRol

            CreateMap<USR_ControlRol, ReadControlRolDto>()
                .ForMember(d => d.Date, o => o.MapFrom(s => s.Date.ToString("dd/MM/yyyy - HH:mm:ss")))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            CreateMap<CreateControlRolDto, USR_ControlRol>()
                .ForMember(d => d.Date, o => o.MapFrom(_ => DateTime.Now))
                .ForMember(d => d.Status, o => o.MapFrom(_ => 1));

            CreateMap<ModifyControlRolDto, USR_ControlRol>();

            CreateMap<ChangeStatusControlRolDto, USR_ControlRol>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));

            #endregion

            #endregion

            #region ROUTE MODULE

            //Add mapping supplier

            #endregion
        }
    }
}
