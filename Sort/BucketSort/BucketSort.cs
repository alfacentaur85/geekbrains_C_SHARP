using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BucketSort
{
    class BucketSort
    {
        int[] sourceArray;

        int ArrayLength { get; set; } = 50;

        int BucketMultipleValue { get; set; } = 20;

        List<List<int>> _bucketArray = new List<List<int>>();

        int MaxValue { get; set; } = 100;
        
        void GenerateSourceArray(int arrayLength)
        {
            sourceArray = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                sourceArray[i] = new Random().Next(MaxValue);
            }
        }

        void FillBucketArray()
        {
            for(int i = 0; i < Math.Ceiling((double) MaxValue / BucketMultipleValue); i++)
            {
                _bucketArray.Add(new List<int>());
            }

            int counterArrayLength = 0;

            while(counterArrayLength < sourceArray.Length)
            {
                _bucketArray[(int)Math.Floor(((double)sourceArray[counterArrayLength]) / BucketMultipleValue)].Add(sourceArray[counterArrayLength]);

                counterArrayLength++;
            }
        }

        void SortBuckets()
        {
            for (int i = 0; i < _bucketArray.Count; i++)
            {
                _bucketArray[i].Sort();
            }
        }

        void MergeBucketsToResulltArray()
        {
            int count = 0;
            for (int i = 0; i < _bucketArray.Count; i++)
            {
                for (int j = 0; j < _bucketArray[i].Count; j++)
                {
                    sourceArray[count] = _bucketArray[i][j];
                    count++;
                }
            }
        }

        public void TestBucketSort(int arrayLength, int bucketMultipleValue, int maxValue)
        {
            MaxValue = maxValue;
            BucketMultipleValue = bucketMultipleValue;
            GenerateSourceArray(arrayLength);
            FillBucketArray();
            Console.WriteLine("Source array:");
            Print(sourceArray);
            Console.WriteLine("\n\nSource buckets:");
            Print(_bucketArray);
            SortBuckets();
            MergeBucketsToResulltArray();
            Console.WriteLine("\n\nSorted buckets:");
            Print(_bucketArray);
            Console.WriteLine("\n\nSorted array:");
            Print(sourceArray);
            Console.WriteLine("\n");
        }

        void DeleteBucketFiles()
        {
            FileInfo fileInf;
            for (int i = 0; i < Math.Ceiling(ArrayLength * 1.0 / BucketMultipleValue); i++)
            {
                try
                {
                    fileInf = new FileInfo(string.Concat("Bucket", i));
                    fileInf.Delete();
                }
                catch { }
            }    
        }

        void SaveArrayToFile()
        {
            using (System.IO.StreamWriter textFile = new System.IO.StreamWriter("sourceArray"))
            {
                for (int i = 0; i < sourceArray.Length; i++)
                {
                        textFile.WriteLine(sourceArray[i]);
                }
            }
            
        }

        void SaveBucketArraysToFiles(int bucketMultipleValue)
        {
            using (FileStream fstream = File.OpenRead("sourceArray"))
            {
                byte[] bytes = new byte[0];
                char[] chars = new char[0];
                string number = "";
                int numBytesRead = 0;
                while (fstream.Position <= fstream.Length)
                {
                    Array.Resize<byte>(ref bytes, bytes.Length + 1);
                    
                    fstream.Position = numBytesRead;
                    bytes[bytes.Length - 1] = (byte)fstream.ReadByte();

                    if (bytes[bytes.Length - 1] == 13) 
                    {
                        
                        Array.Resize<byte>(ref bytes, bytes.Length - 1);

                        chars = new char[bytes.Length];
                        chars = System.Text.Encoding.UTF8.GetString(bytes).ToCharArray();
                        number = null;
                        for (int i = 0; i < chars.Length; i++)
                        {
                            number = String.Concat(number, chars[i]);
                        }
                        Array.Resize<byte>(ref bytes, 0);

                        using (StreamWriter textFile = new StreamWriter(
                               (string.Concat("Bucket", Int32.Parse(number) / bucketMultipleValue)), true))
                        {
                            textFile.WriteLine(number);
                        }
                        numBytesRead++;

                    }

                    numBytesRead++;

                }

            }
        }


        void SortBucketArraysFromFiles()
        {
            for (int i = 0; i < Math.Ceiling(ArrayLength * 1.0 / BucketMultipleValue); i++)
            {
                byte[] bytes = new byte[0];
                List<int> temp = new List<int>();
                string tempStr="";
                using (FileStream fstream = File.OpenRead(string.Concat("Bucket", i)))
                {
                    Array.Resize<byte>(ref bytes, (int)fstream.Length);
                    
                    fstream.Read(bytes, 0, bytes.Length);
                    temp.Clear();
                    for(int j = 0; j < bytes.Length; j++)
                    {
                        if (bytes[j] != 13)
                        {
                            tempStr = tempStr + Convert.ToChar(bytes[j]).ToString();
                        }
                        else
                        {
                            temp.Add(Int32.Parse(tempStr));
                            tempStr = "";
                            
                        }
                        
                    }
                    temp.Sort();
                    fstream.Close();
                    using (StreamWriter textFile = new StreamWriter(string.Concat("Bucket", i), false))
                    {
                        Console.WriteLine("\nSorted Bucket #{0}:", i);
                        for (int k = 0; k < temp.Count; k++)
                        {
                            textFile.WriteLine(temp[k]);
                            Console.Write("{0} ", temp[k]);
                        }
                    }
                }
            } 
        }


        void MergeBucketsToResulltFile()
        {
            FileInfo fileInf = new FileInfo("sourceArray");
            fileInf.Delete();
            using (StreamWriter fstream = new StreamWriter("sourceArray", false)) 
            {
                for (int i = 0; i < Math.Ceiling(ArrayLength * 1.0 / BucketMultipleValue); i++)
                {
                    byte[] bytes = new byte[0];

                    using (FileStream fstream2 = File.OpenRead(string.Concat("Bucket", i)))
                    {
                        Array.Resize<byte>(ref bytes, (int)fstream2.Length);
                        fstream2.Read(bytes, 0, bytes.Length);
                        for (int j = 0; j < bytes.Length; j++)
                        {
                            if (bytes[j] != 13 && bytes[j] != 10)
                            {
                                fstream.Write(Convert.ToChar(bytes[j]));
                                Console.Write("{0}", Convert.ToChar(bytes[j]));
                            }
                            else
                            {
                                fstream.Write(Convert.ToChar((byte)13));
                                Console.Write(" ");
                            }  
                        }
                    }
                }
            }     
        }

        public void TestExtendedSort(int arrayLength, int bucketMultipleValue, int maxValue)
        {
            MaxValue = maxValue;
            BucketMultipleValue = bucketMultipleValue;
            ArrayLength = arrayLength;
            DeleteBucketFiles();
            GenerateSourceArray(arrayLength);
            Console.WriteLine("Source array:");
            Print(sourceArray);
            SaveArrayToFile();
            SaveBucketArraysToFiles(BucketMultipleValue);
            SortBucketArraysFromFiles(); 
            Console.WriteLine("\nSorted array:");
            MergeBucketsToResulltFile();
        }

        static void Print(int[] curArray)
        {  
            for(int i = 0; i < curArray.Length; i++)
            {
                Console.Write("{0} ", curArray[i]);
            }
        }

        static void Print(List<List<int>> bucketArray)
        {
            for (int i = 0; i < bucketArray.Count; i++)
            {
                Console.WriteLine("Bucket #{0}: ", i);
                for(int j = 0; j < bucketArray[i].Count; j++) 
                {
                    Console.Write("{0} ", bucketArray[i][j].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
