using System;
using System.IO;

namespace WriteDirsFilesTreeToFile
{
    class Program
    {

        static string[] arrayDirsFiles = new string[0];

        static void Main(string[] args)
        {
             
            string selectedDir = @GetSelectedDir();

            //save directory and files tree without resursion
            WriteDirTree(selectedDir);

            //save directory and files tree with resursion
            GetDirTreeWithRecursion(selectedDir);
            WriteDirTreeWithRecursion(arrayDirsFiles);




        }

        static string GetSelectedDir()
        {
            Console.WriteLine("Введите корневой каталог, например D:" + '\\' + "test, и нажмите Enter");
            return Console.ReadLine();
        }

        static void WriteDirTree(string selectedDir)
        {
            if (!Directory.Exists(selectedDir)) return;

            string[] entries = Directory.GetFileSystemEntries(selectedDir, "*", SearchOption.AllDirectories);
            
            string fileName = "dirTree.txt";

            File.WriteAllLines(fileName, new string[] { selectedDir });
            File.AppendAllLines(fileName, entries);
        }

        static void GetDirTreeWithRecursion(string selectedDir)
        {
            

            if (!Directory.Exists(selectedDir)) return;
            
            Array.Resize(ref arrayDirsFiles, arrayDirsFiles.Length + 1);
            arrayDirsFiles[arrayDirsFiles.Length - 1] = selectedDir;

            string[] entriesFiles = Directory.GetFiles(selectedDir, "*", SearchOption.TopDirectoryOnly);

            for (int i = 0; i < entriesFiles.Length; i++)
            {
                Array.Resize(ref arrayDirsFiles, arrayDirsFiles.Length + 1);
                arrayDirsFiles[arrayDirsFiles.Length - 1] = entriesFiles[i];
            }
            for (int i = 0; i < Directory.GetDirectories(selectedDir).Length; i++)
            {
                GetDirTreeWithRecursion(Directory.GetDirectories(selectedDir)[i]);
            }
        }

        static void WriteDirTreeWithRecursion(string[] arrayDirsFiles)
        {
            string fileName = "dirTreeRecursion.txt";
            File.WriteAllLines(fileName, arrayDirsFiles);
        }
    }
}
