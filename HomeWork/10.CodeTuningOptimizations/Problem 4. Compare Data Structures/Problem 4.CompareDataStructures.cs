namespace CompareDataStructures
{
    using PhoneBook;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class CompareDataStructures
    {
        public const int numberofCalls = 1000;
        public const int peopleMax = 10000000;

        public static Random phoneGenerator = new Random();
        public static Random peopleGenerator = new Random();
        public static List<Person> peopleList = new List<Person>(); //used to create all data here and afterwards add it in phoneList or phoneDictionary

        public static List<Person> phoneList = new List<Person>();
        public static Dictionary<string, string> phoneDictionary = new Dictionary<string, string>();

        //We do not need return result for this benchmark function, but usually when you perform a search, you perform a return.
        public static string searchPhoneList(string name)
        {
            return phoneList.Find(s => s.Name == name).Name;
        }

        public static string searchPhoneDict(string name)
        {
            return phoneDictionary[name];
        }

        public static void DataGenerator()
        {
            char[] numbers = { '0', '9', '8', '7', '6', '5', '4', '3', '2', '1' };
            char[] letters = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };

            for (int i = 0; i < peopleMax; i++)
            {
                string word = "";
                string phoneNumber = "";
                for (int j = 0; j < 10; j++)
                {
                    word += letters[peopleGenerator.Next(0, 25)];
                    phoneNumber += numbers[phoneGenerator.Next(0, 10)];
                }

                peopleList.Add(new Person(word, phoneNumber));
            }

            foreach (var person in peopleList)
            {
                phoneList.Add(person);
                phoneDictionary.Add(person.Name, person.Phone);
            }
        }

        public static void PrintBooks()
        {
            for (int i = 0; i < peopleList.Count; i++)
            {
                Console.WriteLine(peopleList[i].ToString());
            }
        }

        public static void Main(string[] args)
        {
            DataGenerator();
            //PrintBooks(); //revivew the data generated for the people in peopleList

            List<double> measurementList = new List<double>(); //list for taking the measurements for List
            List<double> measurementDict = new List<double>(); //list for taking the measurements for Dictionary
            Stopwatch watch = new Stopwatch();

            string result = "";

            watch.Start();
            for (int i = 0; i < numberofCalls; i++)
            {
                result = searchPhoneDict(peopleList[phoneGenerator.Next(0, peopleMax)].Name);
                measurementList.Add(watch.Elapsed.TotalMilliseconds);
                watch.Restart();
            }

            Console.WriteLine("List results for {1} calls : {0}", measurementList.Average(), numberofCalls);

            for (int i = 0; i < numberofCalls; i++)
            {
                watch.Restart();
                result = searchPhoneDict(peopleList[phoneGenerator.Next(0, peopleMax)].Name);
                measurementDict.Add(watch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine("Dictonary results for {1} calls : {0}", measurementDict.Average(), numberofCalls);
        }
    }
}
