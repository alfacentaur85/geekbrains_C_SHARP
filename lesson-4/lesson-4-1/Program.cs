using System;

namespace lesson_4_1
{
    class Program
    {
        static string[,] names = new string[4, 3] 
        {
           {"Иванов", "Иван", "Иванович"},
           {"Петров", "Петр", "Петрович"},
           {"Сидоров", "Сидор", "Сидорович"},
           {"Михайлов", "Михаил", "Михайлович"}
        };

        static void Main(string[] args)
        {
            outputFullName(names);
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return firstName + " " + lastName + " " + patronymic;
        }

        static int rndGenerate(int arrayLength)
        {
            Random rnd = new Random();
            return rnd.Next(0, arrayLength - 1);
        }

        static void outputFullName(string[,] names)
        {
            
            for(int i = 0; i < names.GetLength(0); i++)
            {
                Console.WriteLine(GetFullName
                                    (
                                        names[rndGenerate(names.GetLength(0)), 0],
                                        names[rndGenerate(names.GetLength(0)), 1],
                                        names[rndGenerate(names.GetLength(0)), 2]
                                    )
                                   );


            }
        }

    }
}
