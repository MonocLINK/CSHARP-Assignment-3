using System;
using System.Linq;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // comment to run specific part
            partA();
            partB(); 
        }

        static void partA()
        {
            // constant vars
            const int STEPS_POINT_VAL = 5;
            const int YOGA_6_11 = 10;
            const int YOGA_12 = 30;
            const int AEROBICS_6_11 = 20;
            const int AEROBICS_12 = 50;
            const int NUTRITION_1_3 = 10;
            const int NUTRITION_4 = 40;
            const int POINTS_FOR_AMAZON_CARD = 50;


            // input vars
            System.Console.Write("Enter number of days where you had more than 10,000 steps: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter number of yoga classes attended: ");
            int numYogaClasses = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter number of aerobics classes attended: ");
            int numAerobicsClasses = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter number of aerobics classes attended: ");
            int numNutritionMeetings = Convert.ToInt32(Console.ReadLine());

            // calc vars
            int points = 0;
            int numAmazonGiftCards = 0;

            // calculate num of points

            points += numSteps * STEPS_POINT_VAL;   // steps
            // add YOGA_6_11 if between 6 and 11, otherwise check if above 11 to add YOGA_12, otherwise nothing
            points += (numYogaClasses >= 6 && numYogaClasses <= 11) ? YOGA_6_11 : (numYogaClasses > 11) ? YOGA_12 : 0;  // yoga
            points += (numAerobicsClasses >= 6 && numAerobicsClasses <= 11) ? AEROBICS_6_11 : (numAerobicsClasses > 11) ? AEROBICS_12 : 0;  // aerobics
            points += (numNutritionMeetings >= 1 && numYogaClasses <= 3) ? NUTRITION_1_3 : (numYogaClasses > 3) ? NUTRITION_4 : 0;  // nutrition

            // giftcards
            numAmazonGiftCards = points / POINTS_FOR_AMAZON_CARD;

            // output
            System.Console.WriteLine($"Total points for this month: {points}");
            System.Console.WriteLine($"Total Amazon gift cards earned: {numAmazonGiftCards}");
        }

        static void partB()
        {
            // const vars
            const String TEASPOONS = "teaspoons";
            const String TABLESPOONS = "tablespoons";
            const String CUPS = "cups";
            const String QUARTS = "quarts";
            const String GALLONS = "gallons";
            const String LITERS = "liters";

            // input var
            System.Console.WriteLine("Enter the starting unit of measurement: ");
            String startUnit = Console.ReadLine();
            System.Console.WriteLine("Enter amount: ");
            double numInputUnits = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Enter the ending unit of measurement: ");
            String endUnit = Console.ReadLine();
            

            // creates a new list of tuples, which each get the similarity of the input string to the preset
            // const strings. lower = more accurate, finds lowest. not perfectly accurate if you enter more
            // inaccurate inputs, but if you try to type teaspoon, you should get teaspoon
            var inputUnit = (new[] {
                Tuple.Create("teaspoons", GetDamerauLevenshteinDistance(TEASPOONS, startUnit.ToLower())),
                Tuple.Create("tablespoons", GetDamerauLevenshteinDistance(TABLESPOONS, startUnit.ToLower())),
                Tuple.Create("cups", GetDamerauLevenshteinDistance(CUPS, startUnit.ToLower())),
                Tuple.Create("quarts", GetDamerauLevenshteinDistance(QUARTS, startUnit.ToLower())),
                Tuple.Create("gallons", GetDamerauLevenshteinDistance(GALLONS, startUnit.ToLower())),
                Tuple.Create("liters", GetDamerauLevenshteinDistance(LITERS, startUnit.ToLower()))
            }).OrderByDescending(t => t.Item2).Last().Item1;

            var outputUnit = (new[] {
                Tuple.Create("teaspoons", GetDamerauLevenshteinDistance(TEASPOONS, endUnit.ToLower())),
                Tuple.Create("tablespoons", GetDamerauLevenshteinDistance(TABLESPOONS, endUnit.ToLower())),
                Tuple.Create("cups", GetDamerauLevenshteinDistance(CUPS, endUnit.ToLower())),
                Tuple.Create("quarts", GetDamerauLevenshteinDistance(QUARTS, endUnit.ToLower())),
                Tuple.Create("gallons", GetDamerauLevenshteinDistance(GALLONS, endUnit.ToLower())),
                Tuple.Create("liters", GetDamerauLevenshteinDistance(LITERS, endUnit.ToLower()))
            }).OrderByDescending(t => t.Item2).Last().Item1;

            // CONVERSION
            double numOutputUnits = 0;

            // switches through input and output like nested for loop in 2d array
            switch(inputUnit){
                case TEASPOONS:
                    switch(outputUnit){
                        case TABLESPOONS:
                            numOutputUnits = teaspoonsToTablespoons(numInputUnits);
                            break;
                        case CUPS:
                            numOutputUnits = teaspoonsToCups(numInputUnits);
                            break;
                        case QUARTS:
                            numOutputUnits = teaspoonsToQuarts(numInputUnits);
                            break;
                        case GALLONS:
                            numOutputUnits = teaspoonsToGallons(numInputUnits);
                            break;
                        case LITERS:
                            numOutputUnits = teaspoonsToLiters(numInputUnits);
                            break;
                    }
                    break;

                case TABLESPOONS:
                    switch(outputUnit){
                        case TEASPOONS:
                            numOutputUnits = tablespoonsToTeaspoons(numInputUnits);
                            break;
                        case CUPS:
                            numOutputUnits = tablespoonsToCups(numInputUnits);
                            break;
                        case QUARTS:
                            numOutputUnits = tablespoonsToQuarts(numInputUnits);
                            break;
                        case GALLONS:
                            numOutputUnits = tablespoonsToGallons(numInputUnits);
                            break;
                        case LITERS:
                            numOutputUnits = tablespoonsToLiters(numInputUnits);
                            break;
                    }
                    break;

                case CUPS:
                    switch(outputUnit){
                        case TEASPOONS:
                            numOutputUnits = cupsToTeaspoons(numInputUnits);
                            break;
                        case TABLESPOONS:
                            numOutputUnits = cupsToTablespoons(numInputUnits);
                            break;
                        case QUARTS:
                            numOutputUnits = cupsToQuarts(numInputUnits);
                            break;
                        case GALLONS:
                            numOutputUnits = cupsToGallons(numInputUnits);
                            break;
                        case LITERS:
                            numOutputUnits = cupsToLiters(numInputUnits);
                            break;
                    }
                    break;

                case QUARTS:
                    switch(outputUnit){
                        case TEASPOONS:
                            numOutputUnits = quartsToTeaspoons(numInputUnits);
                            break;
                        case TABLESPOONS:
                            numOutputUnits = quartsToTablespoons(numInputUnits);
                            break;
                        case CUPS:
                            numOutputUnits = quartsToCups(numInputUnits);
                            break;
                        case GALLONS:
                            numOutputUnits = quartsToGallons(numInputUnits);
                            break;
                        case LITERS:
                            numOutputUnits = quartsToLiters(numInputUnits);
                            break;
                    }
                    break;

                case GALLONS:
                    switch(outputUnit){
                        case TEASPOONS:
                            numOutputUnits = gallonsToTeaspoons(numInputUnits);
                            break;
                        case TABLESPOONS:
                            numOutputUnits = gallonsToTablespoons(numInputUnits);
                            break;
                        case CUPS:
                            numOutputUnits = gallonsToCups(numInputUnits);
                            break;
                        case QUARTS:
                            numOutputUnits = gallonsToQuarts(numInputUnits);
                            break;
                        case LITERS:
                            numOutputUnits = gallonsToLiters(numInputUnits);
                            break;
                    }
                    break;

                case LITERS:
                    switch(outputUnit){
                        case TEASPOONS:
                            numOutputUnits = litersToTeaspoons(numInputUnits);
                            break;
                        case TABLESPOONS:
                            numOutputUnits = litersToTablespoons(numInputUnits);
                            break;
                        case CUPS:
                            numOutputUnits = litersToCups(numInputUnits);
                            break;
                        case QUARTS:
                            numOutputUnits = litersToQuarts(numInputUnits);
                            break;
                        case LITERS:
                            numOutputUnits = litersToGallons(numInputUnits);
                            break;
                    }
                    break;
            }


            // OUTPUT
            System.Console.WriteLine($"{numInputUnits} {inputUnit} = {numOutputUnits} {outputUnit}");

        }


        // TEASPOON CONVERSIONS
        static double teaspoonsToTablespoons(double numInputUnits)
        {
            return numInputUnits / 3.0;
        }
        static double teaspoonsToCups(double numInputUnits)
        {
            return numInputUnits / 48.0;
        }
        static double teaspoonsToQuarts(double numInputUnits)
        {
            return numInputUnits / 192.0;
        }
        static double teaspoonsToGallons(double numInputUnits)
        {
            return numInputUnits / 768.0;
        }
        static double teaspoonsToLiters(double numInputUnits)
        {
            return numInputUnits / 203.0;
        }

        // TABLESPOON CONVERSIONS
        static double tablespoonsToTeaspoons(double numInputUnits)
        {
            return numInputUnits * 3.0;
        }
        static double tablespoonsToCups(double numInputUnits)
        {
            return numInputUnits / 16.0;
        }
        static double tablespoonsToQuarts(double numInputUnits)
        {
            return numInputUnits / 64.0;
        }
        static double tablespoonsToGallons(double numInputUnits)
        {
            return numInputUnits / 256.0;
        }
        static double tablespoonsToLiters(double numInputUnits)
        {
            return numInputUnits / 67.628;
        }

        // CUP CONVERSIONS
        static double cupsToTeaspoons(double numInputUnits)
        {
            return numInputUnits * 48.0;
        }
        static double cupsToTablespoons(double numInputUnits)
        {
            return numInputUnits * 16.0;
        }
        static double cupsToQuarts(double numInputUnits)
        {
            return numInputUnits / 4.0;
        }
        static double cupsToGallons(double numInputUnits)
        {
            return numInputUnits / 16.0;
        }
        static double cupsToLiters(double numInputUnits)
        {
            return numInputUnits / 4.227;
        }

        // QUART CONVERSIONS
        static double quartsToTeaspoons(double numInputUnits)
        {
            return numInputUnits * 192.0;
        }
        static double quartsToTablespoons(double numInputUnits)
        {
            return numInputUnits * 64.0;
        }
        static double quartsToCups(double numInputUnits)
        {
            return numInputUnits * 4.0;
        }
        static double quartsToGallons(double numInputUnits)
        {
            return numInputUnits / 4.0;
        }
        static double quartsToLiters(double numInputUnits)
        {
            return numInputUnits / 1.057;
        }

        // QUART CONVERSIONS
        static double gallonsToTeaspoons(double numInputUnits)
        {
            return numInputUnits * 768.0;
        }
        static double gallonsToTablespoons(double numInputUnits)
        {
            return numInputUnits * 256.0;
        }
        static double gallonsToCups(double numInputUnits)
        {
            return numInputUnits * 16.0;
        }
        static double gallonsToQuarts(double numInputUnits)
        {
            return numInputUnits * 4.0;
        }
        static double gallonsToLiters(double numInputUnits)
        {
            return numInputUnits * 3.785;
        }

        // LITER CONVERSIONS
        static double litersToTeaspoons(double numInputUnits)
        {
            return numInputUnits * 202.884;
        }
        static double litersToTablespoons(double numInputUnits)
        {
            return numInputUnits * 67.628;
        }
        static double litersToCups(double numInputUnits)
        {
            return numInputUnits * 4.227;
        }
        static double litersToQuarts(double numInputUnits)
        {
            return numInputUnits * 1.057;
        }
        static double litersToGallons(double numInputUnits)
        {
            return numInputUnits / 3.785;
        }


        // found this cool little method from ilike2breakthngs https://stackoverflow.com/a/57961456
        // could be avoided by comparing the input to all of the string literals, and finding which one is equal with a .toLower to avoid case differences
        // just wanted to do something that would be more algorithm intensive and make me think how to do this efficiently and learn new stuff
        static int GetDamerauLevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(s, "String Cannot Be Null Or Empty");
            }

            if (string.IsNullOrEmpty(t))
            {
                throw new ArgumentNullException(t, "String Cannot Be Null Or Empty");
            }

            int n = s.Length; // length of s
            int m = t.Length; // length of t

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            int[] p = new int[n + 1]; //'previous' cost array, horizontally
            int[] d = new int[n + 1]; // cost array, horizontally

            // indexes into strings s and t
            int i; // iterates through s
            int j; // iterates through t

            for (i = 0; i <= n; i++)
            {
                p[i] = i;
            }

            for (j = 1; j <= m; j++)
            {
                char tJ = t[j - 1]; // jth character of t
                d[0] = j;

                for (i = 1; i <= n; i++)
                {
                    int cost = s[i - 1] == tJ ? 0 : 1; // cost
                                                       // minimum of cell to the left+1, to the top+1, diagonally left and up +cost                
                    d[i] = Math.Min(Math.Min(d[i - 1] + 1, p[i] + 1), p[i - 1] + cost);
                }

                // copy current distance counts to 'previous row' distance counts
                int[] dPlaceholder = p; //placeholder to assist in swapping p and d
                p = d;
                d = dPlaceholder;
            }

            // our last action in the above loop was to switch d and p, so p now 
            // actually has the most recent cost counts
            return p[n];
        }
    }
}
