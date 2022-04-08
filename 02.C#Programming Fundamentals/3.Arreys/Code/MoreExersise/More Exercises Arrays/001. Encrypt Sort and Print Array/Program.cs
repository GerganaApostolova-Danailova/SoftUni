using System;
using System.Collections.Generic;
using System.Linq;

namespace _001._Encrypt_Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List <double> final = new List<double>();


            double sumVowel = 0;
            double sumConsonant = 0;
            double sum = 0;
            
            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();

                for (int j = 0; j < name.Length; j++)
                {

                    if (name[j] == 'a' || name[j] == 'e' || name[j] == 'i' || 
                        name[j] == 'o' || name[j] == 'u' || name[j] == 'A' || 
                        name[j] == 'E' || name[j] == 'I' || name[j] == 'O' || 
                        name[j] == 'U')

                    {                    
                        sumVowel += name[j] * (name.Length);
                    }
                    else
                    {                      
                        sumConsonant += name[j]/ (name.Length); 
                    }


                }

                sum = sumVowel + sumConsonant;

                final.Add(sum);

                sumVowel = 0;
                sumConsonant = 0;

            }
            final.Sort();

            for (int k = 0; k < final.Count; k++)
            {
                Console.Write(final[k]);
                Console.WriteLine();
            }
            
        }
    }
}
