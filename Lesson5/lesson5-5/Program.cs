using System;
using System.IO;
using System.Text.Json;

namespace lesson5_5
{
    class Program
    {
        static string filename { get;  } = "tasks.json";

        const int arrayLength = 5;

        static string[] tasksList = new string[arrayLength] { "go to the store", "walk with the dog", "throw out the trash", "do home task", "wash the dishes" };

        static ToDo[] toDo = new ToDo[tasksList.Length];

        static void Main(string[] args)
        {
            Task();

        }

        static void Task()
        {
            CreateFile();
           
            TasksDeserialize();

            Console.WriteLine("Введите номер выполненной задачи и Enter");
             
            TasksSerialize(Convert.ToInt32(Console.ReadLine()));

            TasksDeserialize();
        }

        static bool ExistsFile(string filename)
        {

            return File.Exists(filename) ? true : false;
        }

        static void CreateFile()
        {
            
            if (!ExistsFile(filename))
            {
                for (int i = 0; i < tasksList.Length; i++)
                {
                    ToDo toDo = new ToDo(tasksList[i], false);
                    string json = JsonSerializer.Serialize(toDo);
                    File.AppendAllLines(filename, new[] { json });
                }
            }
        }

        static void TasksSerialize(int numberDoneTask)
        {
            File.WriteAllText(filename, "");
            toDo[numberDoneTask - 1] = new ToDo(tasksList[numberDoneTask - 1], true);
            for (int i = 0; i < tasksList.Length; i++)
            { 
                string json = JsonSerializer.Serialize(toDo[i]);
                File.AppendAllLines(filename, new[] { json });
            }

        }

        static void TasksDeserialize()
        {

            string[] json = File.ReadAllLines(filename);

            
            for (int i = 0; i < tasksList.Length; i++)
            {
                toDo[i] = JsonSerializer.Deserialize<ToDo>(json[i]);
                Console.WriteLine("{0} {1} {2}", toDo[i].IsDone ? "[X]": "", toDo[i].Title, i + 1);

            }
        
        }

    }
}
