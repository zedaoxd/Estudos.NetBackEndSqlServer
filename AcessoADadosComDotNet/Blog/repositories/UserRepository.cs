using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<User> Get() => _connection.GetAll<User>();
        public User Get(int id) => _connection.Get<User>(id);
        public void Create(User user) => _connection.Insert<User>(user);
        
    }
}