using System;
using System.IO;

namespace lesson5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            saveToBinaryFile(getInputByteArray());
        }

        static byte[] getInputByteArray()
        {
            Console.WriteLine("Введите произвольный набор чисел от 0 до 255 и нажмите Enter:");
            string[] strBytes = Console.ReadLine().Split(" ");
            int arrayLength = strBytes.Length;
            byte[] arrayByte = new byte[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                arrayByte[i] = Convert.ToByte(strBytes[i]);
            }
            return arrayByte;
        }

        static void saveToBinaryFile(byte[] arrayByte)
        {
            string filename = "output.bin";
            File.WriteAllBytes(filename, arrayByte);
        }

    }
}
