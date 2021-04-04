using System;
using System.Diagnostics;

namespace QAAutomationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Start(Environment.GetCommandLineArgs());
            }
            catch(IndexOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(string.Format("Ошибка: Запуск приложения производится из командной строки с указанием необходимых параметров"));
                Process.Start("cmd.exe");
             
            }
            
            Console.ReadLine();
        }

        /// <summary>
        /// Метод запускат мониторинг процесса 
        /// </summary>
        /// <param name="arguments">В качестве параметров метода передаётся массив параметров из командной строки, где 1й параметр - наименование процесса,
        /// 2й параметр - допустимое время жизни процесса (в минутах), 3й параметр - частота проверки жизни процесса (в минутах) </param>
        static public void Start(string[] arguments) =>
     ProcessVisor.StartVisor(arguments[1], int.Parse(arguments[2]), int.Parse(arguments[3]));
    }
}
