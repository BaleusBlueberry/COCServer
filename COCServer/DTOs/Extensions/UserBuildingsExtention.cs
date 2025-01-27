using DLA.Models;

namespace COCServer.DTOs.Extensions
{
    public static class UserBuildingsExtention
    {
        public static AppUser ToUser(this RegisterDto Dto)
        {
            return new AppUser
            {
                Email = Dto.Email,
                UserName = Dto.UserName
            };
        }
    }
}
