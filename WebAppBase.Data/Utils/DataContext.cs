using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebAppBase.Data.Maps;

namespace WebAppBase.Data.Utils;

 public class DataContext : DbContext {
        public DbContext Context { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            Context = this;
        }

        protected override void OnModelCreating(ModelBuilder mb) {
            mb.ApplyConfigurationsFromAssembly(typeof(UserMap).GetTypeInfo().Assembly);
       
        }
    }