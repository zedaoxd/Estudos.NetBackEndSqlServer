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

        public void Create(User user)
        {
            user.Id = 0;
            _connection.Insert<User>(user);
        } 

        public void Update(User user)
        {
            if (user.Id != 0)
                _connection.Update<User>(user);
        }

        public void Delete(User user)
        {
            if (user.Id != 0)
                _connection.Delete<User>(user);
        }

        public void Delete(int id)
        {
            if (id != 0)
                _connection.Delete<User>(this.Get(id));
        }

    }
}