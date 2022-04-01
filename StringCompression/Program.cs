using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCompression
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            var input = Console.ReadLine().Replace(" ", "");
            Console.WriteLine(Compression(input));
        }

        static string Compression(string input)
        {
            List<StringDictionary> dictionary = new List<StringDictionary>();

            foreach (var item in input)
            {
                var counter = 0;
                if (!dictionary.Exists(d => d.Letter.Equals(item)))
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == item)
                        {
                            counter++;
                        }
                    }
                    dictionary.Add(new StringDictionary { Letter = item, Number = counter });
                }
            }

            string output = "";
            dictionary.ForEach(d => output = (CheckNumber(dictionary)) ? output + $"{d.Letter}{d.Number}" : output = output + $"{d.Letter}");

            return output;
        }

        static bool CheckNumber(List<StringDictionary> dictionary)
        {
            bool check = false;
            foreach (var item in dictionary)
            {
                if (item.Number != 1)
                {
                    check = true;
                    break;
                }
            }

            return check;
        }
    }
}
