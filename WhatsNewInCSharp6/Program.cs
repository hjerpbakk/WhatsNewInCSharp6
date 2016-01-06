using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            var oldImmutable = new OldImmutableClass("A good value");
            Console.WriteLine("Not really immutable: ");
            Console.Write(oldImmutable.ReadOnlyProperty);
            Console.Write(" ");
            Console.WriteLine(oldImmutable.PseudoImmutableProperty);
            Console.Write("ToString: ");
            Console.WriteLine(oldImmutable);

            Console.WriteLine("");

            var properImmutable = new ProperImmutableClass("A good value");
            Console.WriteLine("Really immutable: ");
            Console.Write(properImmutable.ReadOnlyProperty);
            Console.Write(" ");
            Console.WriteLine(properImmutable.ReadOnlyPropertyWithDefaultValue);
            Console.Write("ToString: ");
            Console.WriteLine(properImmutable);

            Console.WriteLine("");

            var hjerpbakk = new Person("Runar", "Hjerpbakk", 32);
            hjerpbakk.Print();
            Console.WriteLine("Time moves fast...");
            (++hjerpbakk).Print();

            Console.ReadKey();

        }
    }
}
