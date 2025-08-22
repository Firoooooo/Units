using Microsoft.EntityFrameworkCore;
using UnitTExamplesAPI.Models;

namespace UnitTExamplesAPI.Data
{
    public class UnitTExamplesContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public UnitTExamplesContext(DbContextOptions<UnitTExamplesContext> _uNITTExamplesOptions)
            : base(_uNITTExamplesOptions)
        {

        }
    }
}
