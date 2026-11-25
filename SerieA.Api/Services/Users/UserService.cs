using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SerieA.WebApi.Context;
using SerieA.WebApi.DTOs.UserDtos;
using SerieA.WebApi.Entities;
using SerieA.WebApi.Exceptions;

namespace SerieA.WebApi.Services.Users
{
    public class UserService(AppDbContext _context,
                             IMapper _mapper,
                             UserManager<AppUser> _userManager,
                             RoleManager<AppRole> _roleManager) : IUserService
    {

        public async Task CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<AppUser>(createUserDto);
            user.UserName = createUserDto.Email;

            await _userManager.CreateAsync(user, createUserDto.Password);

            if (createUserDto.Roles.Any() == true)
            {
                var role = await _userManager.AddToRoleAsync(user, createUserDto.Roles);
            }

        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                throw new NotFoundException("Kullanıcı bulunamadı.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultUserDto>> GetAllUserAsync()
        {
            var users = await _context.Users.ToListAsync();
            var userList = new List<ResultUserDto>();
            foreach (var user in users)
            {
                var values = _mapper.Map<ResultUserDto>(user);
                values.Roles = (await _userManager.GetRolesAsync(user)).ToList();
                userList.Add(values);
            }

            return userList;
        }

        public async Task<List<ResultRoleDto>> GetRolesAsync()
        {
            return await _roleManager.Roles
                            .Select(r => new ResultRoleDto {
                                    Id = r.Id, 
                                    Name = r.Name })
                            .ToListAsync();
        }

        public async Task<ResultUserDto> GetUserByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                throw new NotFoundException("Kullanıcı bulunamadı.");

            var value = _mapper.Map<ResultUserDto>(user);
            value.Roles = (await _userManager.GetRolesAsync(user)).ToList();
            return value;
        }

        public async Task ToggleUserStatusAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new NotFoundException("Kullanıcı bulunamadı.");

            user.IsActive = !user.IsActive;
            await _userManager.UpdateAsync(user);

        }

        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(updateUserDto.Id.ToString());
            if (user == null)
            {
                throw new NotFoundException("Kullanıcı bulunamadı");
            }

            _mapper.Map(updateUserDto, user);
            user.UserName = updateUserDto.Email;  //E posta değişirse yeni kullanıcı adıyla eşleşsin diye.
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new BadRequestException(string.Join(" ", result.Errors.Select(e => e.Description)));

            var currentRole = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRole);
            await _userManager.AddToRolesAsync(user, updateUserDto.Roles);
        }
    }
}
