using System;
using System.Configuration;
using System.Reflection;


namespace ApplicationSetting
{
 
    class Program
    {
        enum Questions
        {
            Name,
            Age,
            Kind_Activity
        };


        static void Main(string[] args)
        {

            //output version and description
            outputDescriptionVersion();

            //output greeting and settings
            Console.WriteLine(GetGreeting());
            Console.WriteLine();

            //output settings
            OutputSettings(Properties.Settings.Default.username,"UserName");
            OutputSettings(Properties.Settings.Default.age, "Age");
            OutputSettings(Properties.Settings.Default.kindActivity, "Kind_Activity");
            Console.WriteLine();

            //input values of settings and save one
            SaveSettings(GetAnswers());

        }

        static void outputDescriptionVersion()
        {

            Assembly execAssembly = Assembly.GetExecutingAssembly();

            //output Version
            Assembly thisAssem = typeof(Program).Assembly;
            AssemblyName thisAssemName = thisAssem.GetName();

            Version ver = thisAssemName.Version;

            Console.WriteLine("Version: {0} ", ver);

            //output Description
            //Type of attribute that is desired

            Type type = typeof(AssemblyDescriptionAttribute);


            //Is there an attribute of this type already defined?

            if (AssemblyDescriptionAttribute.IsDefined(execAssembly, type))

            {

                //if there is, get attribute of desired type

                AssemblyDescriptionAttribute a = (AssemblyDescriptionAttribute)AssemblyDescriptionAttribute.GetCustomAttribute(execAssembly, type);

                //Print description

                Console.WriteLine($"Description: {a.Description}");

            }      

            Console.WriteLine();
        }


        static string GetGreeting()
        {
            return Properties.Settings.Default.greeting;
        }

        static void OutputSettings(string propertyValue, string comment)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.username))
            {
                Console.WriteLine($"{comment}: {propertyValue}");
            }
        }

        static string[] GetAnswers()
        {
            string[] arrayAnswers = new string[Enum.GetNames(typeof(Questions)).Length];

            foreach (Questions questions in Enum.GetValues(typeof(Questions)))
            {
                Console.Write($"Please, input your { questions }: ");
                arrayAnswers[(int)questions] = Console.ReadLine();
            }

            return arrayAnswers;

        }

        static void SaveSettings(string[] arrayAnswers)
        {

            Properties.Settings.Default.username = arrayAnswers[0];
            Properties.Settings.Default.age = arrayAnswers[1];
            Properties.Settings.Default.kindActivity = arrayAnswers[2];
            Properties.Settings.Default.Save();
       
            Console.ReadKey();

        }




    }
}
