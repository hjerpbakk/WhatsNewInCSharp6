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
                Console.WriteLine("Specify demo, try again. Avaiable demos:");
                Console.WriteLine("");
                Console.WriteLine("properties");
                Console.WriteLine("expressions");
                Console.WriteLine("static");
                Console.WriteLine("nameof");
                Console.WriteLine("null");
                Console.WriteLine("string");
                Console.WriteLine("initializers");
                Console.WriteLine("exceptions");
                return;
            }

            Console.WriteLine(args[0]);
            Console.WriteLine("");
            Console.WriteLine("***********************************");
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
                case "nameof":
                    NameOf();
                    return;
                case "null":
                    Null();
                    return;
                case "string":
                    String();
                    return;
                case "initializers":
                    Initializers();
                    return;
                case "exceptions":
                    Exceptions();
                    return;
            }
        }

        private static Person Runar => new Person("Runar", "Hjerpbakk", 32);

        /// <summary>
        /// Better Auto Properties
        /// </summary>
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

        /// <summary>
        /// Expression-bodied members
        /// </summary>
        private static void Expressions()
        {
            var hjerpbakk = Runar;
            hjerpbakk.Print();
            Console.WriteLine("Time moves fast...");
            (++hjerpbakk).Print();
        }

        /// <summary>
        /// Using static
        /// </summary>
        private static void Static()
        {
            var usingStatic = new UsingStatic(DateTime.Now.DayOfWeek);
            var result = usingStatic.CalculateIfLuckyDay();
            Console.Write("Today is ");
            Console.Write(DateTime.Now.DayOfWeek);
            Console.WriteLine(". Is this our lucky day?");
            Console.WriteLine("");
            Console.WriteLine(result == 42 ? "Yes" : "No");
            Console.WriteLine("");

            usingStatic = new UsingStatic(DayOfWeek.Friday);
            var result2 = usingStatic.CalculateIfLuckyDay();
            Console.Write("What about ");
            Console.Write(DayOfWeek.Friday);
            Console.WriteLine(". Is that our lucky day?");
            Console.WriteLine("");
            Console.WriteLine(result2 == 42 ? "Yes" : "No");
        }

        /// <summary>
        /// nameof expressions
        /// </summary>
        private static void NameOf()
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

        /// <summary>
        /// Null-conditional operator
        /// </summary>
        private static void Null()
        {
            var nullConditionalOperator = new NullConditionalOperator();

            var prescription = new Prescription(Runar, "IPA");

            Console.Write("Should ");
            Console.Write(Runar);
            Console.WriteLine(" get his drug of choice?");

            Console.WriteLine("");
            Console.WriteLine(nullConditionalOperator.ShouldGiveDrug(prescription));
            Console.WriteLine("");

            Console.WriteLine("What if the code is improved?");
            Console.WriteLine("");
            Console.WriteLine(nullConditionalOperator.ShouldGiveImprovedDrug(prescription));
        }

        /// <summary>
        /// String interpolation
        /// </summary>
        private static void String()
        {
            Console.WriteLine("String format is much improved:");
            Console.WriteLine("");

            var stringInterpolation = new StringInterpolation();
            Console.WriteLine("OldWay:");
            Console.WriteLine(stringInterpolation.OldWay(Runar, "Awesome"));
            Console.WriteLine("");

            Console.WriteLine("NewWay:");
            Console.WriteLine(stringInterpolation.OldWay(Runar, "Still Awesome"));
            Console.WriteLine("");

            Console.WriteLine("AlignmentAndFormatCanStillBeUsed:");
            Console.WriteLine(stringInterpolation.AlignmentAndFormatCanStillBeUsed(Runar));
            Console.WriteLine("");

            Console.WriteLine("Age is realative:");
            Console.WriteLine(stringInterpolation.ExpressionsToo(Runar));
            Console.WriteLine("");

            Console.WriteLine("Very realative");
            var newton = new Person("Isaac", "Newton", 373);
            Console.WriteLine(stringInterpolation.ExpressionsToo(newton));
        }

        /// <summary>
        /// Improved Initializers
        /// </summary>
        private static void Initializers()
        {

            // ReSharper disable once NotAccessedVariable
            var improvedInitializers = new ImprovedInitializers
            {
                Runar,
                new Person("Another", "Person", 42)
            };

            // ReSharper disable once RedundantAssignment
            improvedInitializers = new ImprovedInitializers
            {
                { "First", "Last", 7 },
                { "Such", "Savings", 42 },
            };

            Console.WriteLine("It worked!!!");
        }

        /// <summary>
        /// Exception filters
        /// </summary>
        private static void Exceptions()
        {
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    var exceptionFilters = new ExceptionFilters();
                    var result = exceptionFilters.WillItCrash(random.Next(43));
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("We got LUCKY!!! " + result);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                catch (Exception)
                {
                    Console.WriteLine("No luck");
                }
            }
        }
    }
}
