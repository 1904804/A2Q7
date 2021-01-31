using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2Q7
{
    class Program
    {
        static void Main(string[] args)
        {

            int entries; // asks the user for the number of entries they will enter this is also used in the caluclation 
            int i;
            double total = 0; //total is used in the calulations
            double mean;
            double median;

            Console.WriteLine("Please enter the number of values you are going to enter ( max of 10 ) - ");
            entries = Convert.ToInt32(Console.ReadLine());
            int[] values = new int[entries]; //setup the array
            for ( i = 0; i < entries; i++) //Loops through the number of times the user inputed and enters them into the array
            {
                Console.WriteLine("Please enter a value for entry " + i);
                values[i] = Convert.ToInt32(Console.ReadLine());

                total = total + values[i]; //calculates the total value
            }

            mean = total / entries; // works out the mean
            //Displays the answers 
            Console.WriteLine("The total of the values entered is " + total);
            Console.WriteLine(String.Format("The mean of the values you entered is {0:F2}" , mean));//formats answer to 2 decimal places


            //Median function
            Array.Sort(values);

            if (entries%2 ==0)//checks if entries is odd or even to perform the correct calculation
            {
                int arraySize = entries / 2;//calcluates the middle number
                int midNum = arraySize; // to overcome a bug where a number of zero`s are added to to sorted array
                median = values[midNum] + values[midNum -1]; //adds the two middle numbers and divdes by 2
                Console.WriteLine(string.Format("The median of the values entered is {0:F2}" , median / 2));
            }
            else
            {
                int arraySize = values.Length / 2;//calcluates the middle number
                int midNum = arraySize ; // to overcome a bug where a number of zero`s are added to to sorted array
                median = values[midNum]; //gets the value of the middle number
                Console.WriteLine("The median of the values entered is " + median );

            }

            //Mode function using LINQ
            int mode = values.GroupBy(v => v)
                        .OrderByDescending(g => g.Count())
                        .First()
                        .Key;

            Console.WriteLine("The mode of the values is " + mode);


            //Standard Deviation using LINQ

            double differences = values.Select(val => (val - mode) * (val - mode)).Sum();
            double standardDeviation = Math.Sqrt(differences / values.Length);
            Console.WriteLine("The standard deviation is {0:F2}" , standardDeviation);





        }
    }
}
