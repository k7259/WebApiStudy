using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApiStudy.ModelFolder
{
    public class ApplicationDB : DbContext
    {
        public DbSet<IplPlayer>PlayersList { get; set; }
        public string connectionstring;
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)

        {
            
        }
       
    }
}
