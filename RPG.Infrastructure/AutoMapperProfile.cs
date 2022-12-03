using AutoMapper;
using dotnet_rpg.Dtos;
using RPG.Domain.Dtos.Battle;
using RPG.Domain.Dtos.Class;
using RPG.Domain.Dtos.NonPlayerCharacter;
using RPG.Domain.Dtos.PlayerCharacter;
using RPG.Domain.Dtos.StaffMember;
using RPG.Domain.Dtos.Weapon;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.Game;
using RPG.Domain.Model.General;

namespace dotnet_rpg.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // DTOs - business

            CreateMap<StaffMemberRequestDto, StaffMember>();
            CreateMap<StaffMember, StaffMemberResponseDto>();

            CreateMap<PlayerCharacterRequestDto, PlayerCharacter>();
            CreateMap<PlayerCharacter, PlayerCharacterResponseDto>();

            CreateMap<ClassRequestDto, Class>();
            CreateMap<Class, ClassResponseDto>();

            CreateMap<NonPlayerCharacterRequestDto, NonPlayerCharacter>();
            CreateMap<NonPlayerCharacter, NonPlayerCharacterResponseDto>();

            CreateMap<WeaponRequestDto, Weapon>();
            CreateMap<Weapon, WeaponResponseDto>();

            CreateMap<PlayerCharacter, BattleRankingResponseDto>();
            CreateMap<Battle, BattleResponseDto>();
            CreateMap<BattleTurn, BattleTurnResponseDto>();

            // DTOs - system
            CreateMap<HttpException, HttpExceptionDto>();
            CreateMap<HttpExceptionMessage, HttpExceptionMessageDto>();

            // Objects
            CreateMap<PlayerCharacter, PlayerCharacter>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Weapon, Weapon>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<NonPlayerCharacter, NonPlayerCharacter>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Class, Class>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
