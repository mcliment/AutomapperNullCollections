using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Foo
    {
        public virtual int ID { get; set; }

        public virtual ISet<Bar> Bars { get; } = new HashSet<Bar>();

        public virtual ISet<Baz> Bazs { get; } = new HashSet<Baz>();
    }

    public class Bar
    {
        public virtual int ID { get; set; }

        public virtual string Value { get; set; }
    }

    public class Baz
    {
        public virtual int ID { get; set; }

        public virtual string Value { get; set; }
    }

    public class FooDto
    {
        public int ID { get; set; }

        public List<BarDto> Bars { get; set; }

        public List<BazDto> Bazs { get; set; }
    }

    public class BarDto
    {
        public int ID { get; set; }

        public string Value { get; set; }
    }

    public class BazDto
    {
        public int ID { get; set; }

        public string Value { get; set; }
    }
}
