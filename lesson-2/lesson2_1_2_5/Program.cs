using System;

namespace Lesson2_1_2_5
{
    class Program
    {
        enum Months
        {
            January,
            Ferbuary,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        };
        static void Main(string[] args)
        {
            Console.Write("Введите максимальную суточную температуру: ");

            double maxTemperature = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите минимальную суточную температуру: ");

            double minTemperature = Convert.ToDouble(Console.ReadLine());

            double avgTemperature = Math.Round((maxTemperature + minTemperature) / 2, 2);

            Console.WriteLine($"Среднесуточная температура: {avgTemperature}");

            Console.Write("Введите номер текущего месяца: ");

            int currentMonth = Convert.ToInt32(Console.ReadLine());

            Months month = (Months)Enum.GetValues(typeof(Months)).GetValue(currentMonth - 1);

            Console.WriteLine($"Текущий месяц: {month}");

            if ((currentMonth == 1 || currentMonth == 2 || currentMonth == 3) && (avgTemperature > 0))
            {
                Console.WriteLine("Дождливая зима");
            }

        }
    }
}
