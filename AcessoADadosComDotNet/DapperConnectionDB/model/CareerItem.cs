using System;

namespace DapperConnectionDB.model
{
    public class CareerItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Course course { get; set; }
    }
}