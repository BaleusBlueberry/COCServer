using DLA.Interface;
using DLA.Models;
using MongoDB.Driver;

namespace DLA.Repository.AuthRepositories;

public class AuthRepository : MongoAuthRepository<AppUser>
{
    public AuthRepository(IMongoService mongo) : base(mongo)
    {
    }
    public async Task<AppUser?> FindByEmail(string email)
    {
        return await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
    }

    public async Task<AppUser?> FindByUserName(string userName)
    {
        return await _collection.Find(u => u.UserName == userName).FirstOrDefaultAsync();
    }
}
