using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MyContext : DbContext
    {
        public MyContext() : base("AutomapperNullCollections")
        {
        }

        public DbSet<Foo> Foos { get; set; }

        public DbSet<Bar> Bars { get; set; }

        public DbSet<Baz> Bazs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(typeof(MyContext).Assembly);
        }
    }

    public class FooConfiguration : EntityTypeConfiguration<Foo>
    {
        public FooConfiguration()
        {
            HasMany(m => m.Bars).WithMany();
            HasMany(m => m.Bazs).WithMany();
        }
    }
}
