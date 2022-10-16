

using Microsoft.EntityFrameworkCore;
using Leasing.API.App.Domain.Models;

namespace Leasing.API.App.Shared.Persistence.Contexts;

public class AppDbContext:DbContext
{
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*-----------------------Properties and keys-----------------------*/

        }
}
