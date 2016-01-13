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
            if (args.Length != 1)
            {
                Console.WriteLine("Specify demo");
                return;
            }

            switch (args[0])
            {
                case "properties":
                    Properties();
                    return;
                case "expressions":
                    Expressions();
                    return;
                case "static":
                    Static();
                    return;
            }
        }

        private static Person Runar => new Person("Runar", "Hjerpbakk", 32);

        private static void Static()
        {
            try
            {
                // ReSharper disable once ObjectCreationAsStatement
                new NameOf(null);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

            var nameOf = new NameOf(Runar);
            nameOf.PropertyChanged += (sender, args) => Console.WriteLine("Property name: " + args.PropertyName);

            Console.WriteLine(nameOf);
            Console.WriteLine("Swap");
            nameOf.Swap();
            Console.WriteLine(nameOf);
        }

        private static void Expressions()
        {
            var hjerpbakk = Runar;
            hjerpbakk.Print();
            Console.WriteLine("Time moves fast...");
            (++hjerpbakk).Print();
        }

        private static void Properties()
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
        }
    }
}
