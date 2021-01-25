using System;

namespace Lesson2_6
{
    class Program
    {
        [Flags]
        public enum daysOfWeek
        {
            Monday = 0b_1000000,
            Tuesday = 0b_0100000,
            Wednesday = 0b_0010000,
            Thursday = 0b_0001000,
            Friday = 0b_0000100,
            Suturday = 0b_0000010,
            Sunday = 0b_0000001
        };
        static void Main(string[] args)
        {


            //офис 1 работает со вторника до пятницы
            daysOfWeek office1 = daysOfWeek.Tuesday | daysOfWeek.Wednesday | daysOfWeek.Thursday |
                daysOfWeek.Friday;

            //офис 2 работает с понедельника до воскресенья
            daysOfWeek office2 = daysOfWeek.Monday | daysOfWeek.Tuesday |
                daysOfWeek.Wednesday | daysOfWeek.Thursday |
                daysOfWeek.Friday | daysOfWeek.Suturday | daysOfWeek.Sunday;
           
    }
}
}
