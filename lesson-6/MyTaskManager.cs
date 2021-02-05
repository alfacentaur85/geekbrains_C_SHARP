using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace TaskManager
{
    public class MyTaskManager
    {
        public void GetAndOutputProcessList()
        {
            try
            {
                Process[] processes = Process.GetProcesses();
            
                for (int i = 0; i < processes.Length; i++)
                {
                    Console.WriteLine($"{processes[i].Id} {processes[i].ProcessName}");
                }
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
            }
                 
        }

        public int GetIdProcessToKill()
        {
            Console.WriteLine();
            Console.WriteLine("Введите ID процесса и нажмите Enter для его завершения. Для выхода из программы введите q и нажмите Enter");
            string inputStr = Console.ReadLine();
            try
            {
                return  Convert.ToInt32(inputStr);
            }
            catch 
            {
                return inputStr == "q" ? -1 : -2;
                    
            }
            
        }

        public void TaskKill(int idProcess)
        {
            try
            {
                Process process = Process.GetProcessById(idProcess);
                process.Kill();
                Console.WriteLine($"Процесс {process.ProcessName} c ID {idProcess} успешно завершен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Что-то пошло не так. Попробуйте ещё раз.");
            }
        }
    }
}
