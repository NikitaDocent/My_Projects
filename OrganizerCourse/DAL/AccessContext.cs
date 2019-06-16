using System.Data.Entity;
using Entity;

namespace DAL
{
    public class AccessContext : DbContext
    {
        public AccessContext(string connectString) : base(connectString)
        {
            Database.SetInitializer<AccessContext>(new DropCreateDatabaseIfModelChanges<AccessContext>());
        }

        public DbSet<Component> Components { get; set; }
    }
}
