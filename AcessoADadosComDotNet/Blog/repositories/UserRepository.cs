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
        public IEnumerable<User> Get()
        {
            using (var conection = new SqlConnection(StringConnection.Connection))
            {
                return conection.GetAll<User>();
            }
        }
    }
}