using System.Collections.Generic;
using System.Linq;
using Blog.models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(SqlConnection connection) : base(connection)
        {
        }

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT 
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (u, r) =>
                {
                    var user = users.FirstOrDefault(x => x.Id == u.Id);
                    if (user == null)
                    {
                        user = u;
                        if (r != null)
                            user.Roles.Add(r);

                        users.Add(user);
                    }
                    else
                    {
                        users.Add(user);
                    }
                    return user;
                }
            , splitOn: "Id");


            return users;
        }
    }
}