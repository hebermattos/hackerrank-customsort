using System;
using System.Collections.Generic;
using System.Linq;

namespace custom_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 3, 7, 3, 1, 5, 4, 2, 7, 5, 5 };

            List<int> result = CustomSort(numbers);

            Console.WriteLine(String.Join(", ", result));
        }

        private static List<int> CustomSort(List<int> numbers)
        {
            var distinctNumbers = numbers.Distinct();

            var frequencyList = new List<frequency>();

            foreach (var number in distinctNumbers)
                frequencyList.Add(new frequency { Number = number, Frequency = numbers.Count(x => x == number) });

            frequencyList = frequencyList.OrderBy(x => x.Frequency).ToList();
            var distinctFrequencies = frequencyList.Select(x => x.Frequency).OrderBy(x => x).Distinct();

            var result = new List<int>();

            foreach (var frequency in distinctFrequencies)
            {
                var numbersSameFrequency = frequencyList.Where(x => x.Frequency == frequency).Select(x => x.Number).OrderBy(x => x);

                foreach (var number in numbersSameFrequency)
                {
                    for (int i = 0; i < frequency; i++)
                        result.Add(number);
                }
            }

            return result;
        }
    }

    public struct frequency
    {
        public int Number { get; set; }
        public int Frequency { get; set; }

        public override string ToString()
        {
            return Frequency + " - " + Number;
        }
    }
}