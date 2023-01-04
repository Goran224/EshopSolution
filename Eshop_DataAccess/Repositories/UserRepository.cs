using Eshop_DataAccess.Interfaces;
using Eshop_Domain;
using Eshop_Domain.Entities;
using Eshop_Shared;
using Microsoft.EntityFrameworkCore;

namespace Eshop_DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EShopDbContext _dbContext;


        public UserRepository(EShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUser(User userModel)
        {
            var userExist = await _dbContext.User.FirstOrDefaultAsync(x => x.Email == userModel.Email);
            if (userExist != null) throw new Exception(ErrorMessages.UserAlredyExist);

            try
            {
                var user = new User()
                {
                    Email = userModel.Email,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Password = userModel.Password,
                };

                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return user;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUser(string email, string password)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
