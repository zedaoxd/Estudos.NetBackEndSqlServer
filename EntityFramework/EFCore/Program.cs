using System;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new DBApp())
            {
                // var client = new Client() { Name = "Joao"};
                // db.Clients.Add(client);

                // db.Clients.Add(new Client{Name = "Maria"});
                // db.Clients.Add(new Client{Name = "Bruno"});

                // var a = db.Clients.Find(1);
                // Console.WriteLine(a.Name);
                // db.SaveChanges();

                // SearchClients(db);
                // UpdateClient(db, 2, "Paulo");
                // SearchClients(db);

                DeleteClient(db, 3);
            }

        }

        private static void SearchClients(DBApp db) 
        {
            foreach (var item in db.Clients)
            {
                Console.WriteLine($"Client: {item.Id} - {item.Name}");
            }
        }

        private static void UpdateClient(DBApp db, int id, string name)
        {
            var client = db.Clients.Find(id);
            if (client != null)
            {
                client.Name = name;
                db.SaveChanges();
            }
        }
    
        private static void DeleteClient(DBApp db, int id) 
        {
            var client = db.Clients.Find(id);
            if (client != null)
            {
                db.Remove(client);
                db.SaveChanges();
            }  
        }
    }
}
