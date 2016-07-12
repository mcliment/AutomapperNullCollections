using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common;

namespace Automapper4
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.AllowNullCollections = true;

                c.CreateMap<Foo, FooDto>()
                    .ForMember(d => d.Bars, o => o.ExplicitExpansion())
                    .ForMember(d => d.Bazs, o => o.ExplicitExpansion());

                c.CreateMap<Bar, BarDto>();
                c.CreateMap<Baz, BazDto>();
            });

            var context = new MyContext();

            var foos = context.Foos.AsNoTracking()
                .ProjectTo<FooDto>(cfg, m => m.Bars)
                .ToList();

            Debug.Assert(foos[0].Bars != null);
            Debug.Assert(foos[0].Bazs == null);
        }
    }
}
