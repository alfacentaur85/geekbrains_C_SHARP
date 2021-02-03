using System;

namespace lesson_4_3
{
    enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    };
    class Program
    {
        static void Main(string[] args)
        {
            outputSeasonName();
        }

        static Season findSeasonEng(int nMonth)
        {
            return (Season)Enum.GetValues(typeof(Season)).GetValue(nMonth - 1); 
        }

        static string findSeasonRus(Season season)
        {
            switch (season)
            {
                case Season.Winter:
                    return "зима";
                    break;
                case Season.Spring:
                    return "весна";
                    break;
                case Season.Summer:
                    return "лето";
                    break;
                case Season.Autumn:
                    return "осень";
                    break;
                default:
                    return "";
                    break;
            };
        }

        static void outputSeasonName()
        {
            int nMonth = 0;
            bool flag = false;
            Console.Write("Введите порядковый номер месяца: ");
            do
            {
                nMonth = Convert.ToInt32(Console.ReadLine());
                if (nMonth > 0 && nMonth < 13)
                {
                    flag = true;
                }
                else
                {
                    Console.Write("Ошибка: введите число от 1 до 12: ");
                }
            }
            while (!flag);

            Console.WriteLine($"Название месяца на английском: {findSeasonEng(nMonth)}");
            Console.WriteLine($"Название месяца на руском: {findSeasonRus(findSeasonEng(nMonth))}");


        }
    }

    

}
