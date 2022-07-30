using System;
using System.Collections.Generic;

namespace DapperConnectionDB.model
{
    public class Career
    {
        public Career()
        {
            Items = new List<CareerItem>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<CareerItem> Items { get; set; }
    }
}