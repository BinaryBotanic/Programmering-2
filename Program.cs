using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moment_3.Bedömningsuppgift_Geometri
{
    abstract class Figur
    {
        // Abstrakta egenskaper för area och omkrets
        public abstract double Area { get; }
        public abstract double Omkrets { get; }

        // Abstract metoder för subklasser
        public abstract double getArea();
        public abstract double getOmkrets();
        public abstract string getFigureName();
    }

    // Subklass för Cirkel
    class Cirkel : Figur
    {
        private double radie;

        public Cirkel(double radie)
        {
            this.radie = radie; 
        }

        // Beräkning av area
        public override double Area => Math.PI * radie * radie;

        // Beräkning av omkrets
        public override double Omkrets => 2 * Math.PI * radie;

        // Returnerar figurens area
        public override double getArea() => Area;

        // Returnerar figurens omkrets
        public override double getOmkrets() => Omkrets;

        // Returnerar namnet på figure
        public override string getFigureName() => "Cirkel";

        }

    // Subklass Rektangel
    class Rektangel : Figur
    {
        // Lagrar längd och bredd
        private double längd;
        private double bredd;

        // Integrerar mått för rektangel
        public Rektangel(double längd, double bredd)
        {
            this.längd = längd;
            this.bredd = bredd;
        }

        // Beräkning av area
        public override double Area => längd * bredd;

        // Beräkning av omkrets
        public override double Omkrets => 2 * (längd + bredd);

        // Returnerar figurens area
        public override double getArea() => Area;

        // Returnerar figurens omkrets
        public override double getOmkrets() => Omkrets;

        // Returnerar namnet på figure
        public override string getFigureName() => "Rektangel";
    }

    // Subklass kvadrat
    class Kvadrat : Figur
    {
        // Lagrar sidolängd
        private double sida;

        public Kvadrat(double sida)
        {
            this.sida = sida;
        }

        // Beräkning av area
        public override double Area => sida * sida;

        // Beräkning av omkrets
        public override double Omkrets => 4 * sida;

        // Returnerar figurens are
        public override double getArea() => Area;

        // Returnerar figurens omkrets
        public override double getOmkrets() => Omkrets;
        
        // Returnerar namnet på figure
        public override string getFigureName() => "Kvadrat";
    }

    // Subklass Triangel
    class Triangel : Figur
    {
        // Lagrar info om längd på sida a, b och c
        private double a, b, c;

        public Triangel(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double Area
        {
            get
            {
                // BEräknar halva omkrättsen
                double s = (a + b + c) / 2;

                // Använder Fprmel för att retunera triangelns area
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
        }

        // Omkrets för triangel
        public override double Omkrets => a + b + c;

        // Returnerar figurens are
        public override double getArea() => Area;

        // Returnerar figurens omkrets
        public override double getOmkrets() => Omkrets;

        // Returnerar namnet på figure
        public override string getFigureName() => "Triangel";
    }

    // Meny för användare
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Vänligen välj ett av följande alternativ:");
                Console.WriteLine("1. Cirkel");
                Console.WriteLine("2. Rektangel");
                Console.WriteLine("3. Kvadrat");
                Console.WriteLine("4. Triangel");
                Console.WriteLine("5. Avsluta programmet");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Felaktig inmatning, var vänlig och försök igen");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Ange radie för cirkeln");
                        double radie = double.Parse(Console.ReadLine());
                        Cirkel cirkel = new Cirkel(radie);
                        PrintFigureInfo(cirkel);
                        break;

                    case 2:
                        Console.Write("Ange längd för rektangeln: ");
                        double längd = double.Parse(Console.ReadLine());
                        Console.Write("Ange bredd för rektangeln: ");
                        double bredd = double.Parse(Console.ReadLine());
                        Rektangel rektangel = new Rektangel(längd, bredd);
                        PrintFigureInfo(rektangel);
                        break;
                    case 3:
                        Console.Write("Ange sida för kvadraten: ");
                        double sida = double.Parse(Console.ReadLine());
                        Kvadrat kvadrat = new Kvadrat(sida);
                        PrintFigureInfo(kvadrat);
                        break;
                    case 4:
                        Console.Write("Ange sida a för triangeln: ");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("Ange sida b för triangeln: ");
                        double b = double.Parse(Console.ReadLine());
                        Console.Write("Ange sida c för triangeln: ");
                        double c = double.Parse(Console.ReadLine());
                        Triangel triangel = new Triangel(a, b, c);
                        PrintFigureInfo(triangel);
                        break;
                    case 5:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Felaktigt val, var vänlig och försök igen");
                        break;
                }
            }
        }

        //Metod för att skriva ut info om figurer
        static void PrintFigureInfo(Figur figur)
        {
            Console.WriteLine($"Figur: {figur.getFigureName()}");
            Console.WriteLine($"Omkrets: {figur.getOmkrets()}");
            Console.WriteLine($"Area: {figur.getArea()}");
            Console.WriteLine();
        }
    }
}
