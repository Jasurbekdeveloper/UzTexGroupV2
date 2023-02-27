using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Domain.Enums;
using UzTexGroupV2.Infrastructure.Authentication;

namespace UzTexGroupV2.Application.MappingProfiles;

public static class UserMap
{
    public static User MapToUser(
        CreateUserDto createUserDto,
        IPasswordHasher passwordHasher)
    {
        string randomsalt = Guid.NewGuid().ToString();

        return new User
        {
            FirstName = createUserDto.firstName,
            LastName = createUserDto.lastName,  
            Email = createUserDto.email,
            UserRole = Role.Admin,
            Salt = randomsalt,
            PasswordHash = passwordHasher.GeneratePassword(
                createUserDto.password,
                randomsalt)
        };
    }
    public static UserDto MapToUserDto(User user) =>
        new UserDto(user.Id, user.FirstName, user.LastName, user.Email, user.UserRole);

    public static void MapToUser(ModifyUserDto modifyUserDto, User user)
    {
        user.FirstName = modifyUserDto.firstName ?? user.FirstName;
        user.LastName = modifyUserDto.lastName ?? user.LastName;
        user.Email = modifyUserDto.email ?? user.Email;
    }
}
