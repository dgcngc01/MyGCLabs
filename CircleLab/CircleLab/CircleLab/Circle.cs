using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircleLab;

namespace CircleLab
{
    public class Circle
    {
        public static void GreetPerson()
        {
            Console.WriteLine("Hello, Welcome to Grand Circus' Circle Lab");
            Console.WriteLine("Hope you are well.");
        }
        private float radius;
        
        public static double CalculateCircumference(double inputNumCirc)         // unformatted
        { 
        double circumference = 2 * Math.PI * inputNumCirc;
        return circumference;
        }

        public static string CalculateFormattedCircumference(double inputNumCirc)
        {
            double circumference = 2 * Math.PI * inputNumCirc;
            return circumference.ToString("n2");
        }

        public static double CalculateArea(double inputNumArea)         // unformatted
        {
            double calcArea = Math.PI * inputNumArea * inputNumArea;
            return calcArea;
        }

        public static string CalculateFormattedArea(double inputNumArea)
        {
            double calcArea = Math.PI * inputNumArea * inputNumArea;
            return calcArea.ToString("n2");
        }

        public static string FormattedNumber(double numberSent)
        {
            return numberSent.ToString("n2");
        }


        /*            
                    public string CalculateFormattedCircumference()
                { }
                public double CalculateArea()
                { }
                public string CalculateFormattedArea()
                { }
                private string FormatNumber(double x)
                { }
                */

    }
}
