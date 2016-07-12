using System.Collections.Generic;
using System.Data.Entity;

namespace Common
{
    public class MyContextInitializer : DropCreateDatabaseAlways<MyContext>
    {
        public override void InitializeDatabase(MyContext context)
        {
            base.InitializeDatabase(context);

            var foo1 = new Foo();
            var foo2 = new Foo(); // { Bars = new List<Bar>() };
            var foo3 = new Foo(); // { Bars = new List<Bar>() };

            context.Foos.Add(foo1);
            context.Foos.Add(foo2);
            context.Foos.Add(foo3);

            context.SaveChanges();

            var bar1 = new Bar { Value = "bar1" };
            var bar2 = new Bar { Value = "bar2" };

            foo2.Bars.Add(bar1);

            foo3.Bars.Add(bar1);
            foo3.Bars.Add(bar2);

            context.Bars.Add(bar1);
            context.Bars.Add(bar2);

            context.SaveChanges();
        }
    }
}