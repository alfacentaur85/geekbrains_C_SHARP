using System;


namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTaskManager myTaskManager = new MyTaskManager();
            myTaskManager.GetAndOutputProcessList();
            int id;
            do
            {
                id = myTaskManager.GetIdProcessToKill();
                switch(id)
                {
                    case -2 : 
                        Console.WriteLine("Вы ввели некорректный ID. Поторите попытку");
                        break;
                    case -1 :
                        break;
                    default :
                        myTaskManager.TaskKill(id);
                        break;
                }                   
            }
            while (id != -1);
        }
    }
}
