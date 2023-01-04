using Eshop_Domain.DTO;
using Eshop_Domain.Entities;
using Eshop_Service.Models;

namespace Eshop_Service.Interfaces
{
    public interface IUserService
    {
        Task<int> Create(UserDto userDtoModel);
        Task<JwtResponseModel> Login(LoginModel userDtoModel);
        Task<User> GetUserByEmail(string email);
    }
}
