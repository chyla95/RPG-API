using AutoMapper;
using RPG.Domain.Dtos;
using RPG.Domain.Dtos.Battle;
using RPG.Domain.Dtos.Class;
using RPG.Domain.Dtos.NonPlayerCharacter;
using RPG.Domain.Dtos.PlayerCharacter;
using RPG.Domain.Dtos.Staff;
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

            CreateMap<StaffRequestDto, Staff>();
            CreateMap<Staff, StaffResponseDto>();

            CreateMap<RoleRequestDto, Role>();
            CreateMap<Role, RoleResponseDto>();

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

            // E2E
            CreateMap<Role, Role>()
                .ForMember(e => e.Id, opt => opt.Ignore());

            CreateMap<PlayerCharacter, PlayerCharacter>()
                .ForMember(e => e.Id, opt => opt.Ignore());

            CreateMap<Weapon, Weapon>()
                .ForMember(e => e.Id, opt => opt.Ignore());

            CreateMap<NonPlayerCharacter, NonPlayerCharacter>()
                .ForMember(e => e.Id, opt => opt.Ignore());

            CreateMap<Class, Class>()
                .ForMember(e => e.Id, opt => opt.Ignore());
        }
    }
}
