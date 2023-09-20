using System;
using System.Collections.Generic;
using System.Linq;

namespace Harisane
{
    class Program
    {
        static Dictionary<string, long> CompanyName_Value = new Dictionary<string, long>();
        static Dictionary<long, long> Value_Profit = new Dictionary<long, long>();
        static  (long[] , long []) Sort(Dictionary<long, long> PiWi)
        {
            int Count = PiWi.Count;
            long[] sortedValue = new long[Count];
            long[] sortedKey= new long[Count];
            //long Max = 0;
            // sort ba pi/wi divonne na ba value

            long[] Value = new long[Count];
            long[] Key = new long[Count];
                 
            int k = 0; 
            foreach (KeyValuePair<long, long> ele1 in PiWi)
            {
                Value[k] = ele1.Value;
                Key[k] = ele1.Key;
                k++;
            }


                long Max = -1, Mid1=0;
                int nesahn = 0;
            
            for (int i = 0; i < Count; i++)
            {
                Max = Value[i] / Key[i];
                nesahn = i;
                for (int j = 0; j < Count; j++)
                {


                    Mid1 = Value[j] / Key[j];
                    if (Max  < Mid1)
                    {
                        Max = Mid1;
                        nesahn = j;
                    }
                    else
                    {
                        continue;
                    }
                }
                sortedValue[i] = Value[nesahn];
                sortedKey[i] = Key[nesahn];
                Key[nesahn] = 1;
                Value[nesahn] = 0;

            }

           

            return (sortedKey, sortedValue);
           

        }
        static long knapSackGreedy(int M, long[] key,long[] value , int n)
        {
            long[] input = new long[n];
            long Sum =0, limit = 0;

            limit = key[0];
            for (int i = 0; i <n; i++)
            {
                if(i==0 && limit < M)
                {
                    Sum  = Sum + value[0];
                    input[0] = key[0];
                }
                limit += key[i];
                if (i!=0 && limit < M)
                {
                    input[i] = key[i];                   
                    Sum = Sum + value[i];
                }

            }


            
                
            for (int i = 0; i < input.Length; i++)
            {
                var keysWithMatchingValues = CompanyName_Value.Where(p => p.Value == input[i]).Select(p => p.Key);
                foreach (var key1 in keysWithMatchingValues)
                    Console.WriteLine($"\tSaham with company Name :  {key1}  and Weight or Value: {input[i]} and Profit:  {Value_Profit[input[i]]} is choised");
            }

            return Sum ;
        }
        static void Main(string[] args)
        {




            Console.WriteLine("Enter number of  inputs:");


            int Num;
            Num = Int32.Parse(Console.ReadLine());
            //Dictionary<string, long> CompanyName_Value = new Dictionary<string, long>();
            //Dictionary<long, long> Value_Profit = new Dictionary<long, long>();


            Console.WriteLine("Enter The companies Name and their values each value must be after the company Name:");
            for (int i = 0; i < Num; i++)
            {
               
                string first;
                long second = 0;
                Console.WriteLine($"{i} Enter The company Name ");

              first = Console.ReadLine();
                Console.WriteLine($"{i} Enter The Value ");
                second = long.Parse(Console.ReadLine());
                CompanyName_Value.Add(first, second);

            }

         
         
            foreach (KeyValuePair<string, long> ele1 in CompanyName_Value)
            {
                Console.WriteLine($"ENter the Profit for this Company:{ele1.Key} with this Value{ele1.Value}");
                long profit;
                profit = long.Parse(Console.ReadLine());
                Value_Profit.Add(ele1.Value, profit);
            }



            Console.WriteLine("Your Inputs are :\nvalueOfsaham  -  Profit ");
            foreach (KeyValuePair<long, long> ele1 in Value_Profit)
            {
                Console.WriteLine("{0}              :     {1} ",
                            ele1.Key, ele1.Value);
            }

            Console.WriteLine();

            // long[] val = new long[] { 60, 100, 120 };
            //long[] wt = new long[] { 10, 20, 30 };

            Console.WriteLine("Enter the Maximum weight:\n");

            int W = Int32.Parse(Console.ReadLine());
            //int n = val.Length;

            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            SW.Start();
            long Result = knapSackGreedy(W, Sort(Value_Profit).Item1, Sort(Value_Profit).Item2, Num);
            Console.WriteLine("Result is:");
            Console.WriteLine(Result);
            SW.Stop();

            //long[] SecondResult = knapSackGreedy(W, Sort(Value_Profit).Item1, Sort(Value_Profit).Item2, Num).Item2;

            Console.WriteLine(SW.ElapsedMilliseconds.ToString());

            //for (int i = 0; i < SecondResult.Length; i++)
            //{
            //    Console.WriteLine(SecondResult[i]);
            //}


            Console.ReadLine();
        }
    }
}
