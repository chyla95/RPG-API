﻿using Microsoft.EntityFrameworkCore;
using RPG.Application.Services;
using RPG.Domain.Model;
using RPG.Infrastructure.DataAccess;

namespace RPG.Infrastructure.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _dataContext;

        public WeaponService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Weapon> GetWeapon(int id)
        {
            Weapon weapon = await _dataContext.Weapons.SingleAsync(w => w.Id == id);
            return weapon;
        }
    }
}