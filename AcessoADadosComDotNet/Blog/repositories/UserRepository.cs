using Blog.models;
using Microsoft.Data.SqlClient;

namespace Blog.repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(SqlConnection connection) : base(connection)
        {
        }
    }
}