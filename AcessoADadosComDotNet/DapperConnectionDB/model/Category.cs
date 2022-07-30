using System;

namespace DapperConnectionDB.model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }

        public Category()
        {
        }

        public Category(Guid id, string title, string url, string summary, int order, string description, bool featured)
        {
            Id = id;
            Title = title;
            Url = url;
            Summary = summary;
            Order = order;
            Description = description;
            Featured = featured;
        }

        public override string ToString()
        {
            return $"{Id} - {Title} - {Url} - {Summary} - {Order} - {Description} - {Featured}";
        }
    }
}