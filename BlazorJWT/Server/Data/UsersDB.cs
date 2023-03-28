using BlazorJWT.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorJWT.Server.Data
{
    public class UsersDB:DbContext
    {
        public UsersDB(DbContextOptions<UsersDB> options ):base(options)
        {
            
        }
        public DbSet<UserModel> UserModels { get; set; }
    }
}
