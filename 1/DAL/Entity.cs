using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DesignAgency;
using DAL.Repository;

namespace DAL
{
    public class Entity : DbContext
    {
       
        public Entity(string connectString) : base(connectString)
        {
            Database.SetInitializer<Entity>(new DropCreateDatabaseIfModelChanges<Entity>());
        }
        public DbSet<DesignService> DesignService { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
