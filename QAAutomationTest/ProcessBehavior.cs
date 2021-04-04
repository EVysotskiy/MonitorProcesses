using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

static class ProcessVisor
{
    static public void StartVisor(string nameProcess, int processLife, int frequencyChek)
    {
        ProcessBehavior processVisor = new ProcessBehavior(nameProcess, processLife, frequencyChek);
    }
}

    class ProcessBehavior 
    {
    
    /// <summary>
    /// Найденные процессы 
    /// </summary>
        protected Process[] _process;

    /// <summary>
    /// Время жизни процесса (в минутах)
    /// </summary>
        private int _processLife;

    /// <summary>
    /// Интервал проверки жизни процесса (в минутах)
    /// </summary>
        private int _frequencyChek;
        public int processLife
        {
            get
            {
                return _processLife;
            }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Время жизни процесса не может быть меньше нуля");
                }
                else
                {
                    _processLife = value;
                }
            }
        }

        public int frequencyChek
        {
            get
            {
                return _frequencyChek;
            }

            private set
            {
                if (value < 1)
                {
                    throw new Exception("Интрвал времени проверки процесса не может быть меньше одной минуты");
                }
                else
                {
                    _frequencyChek = value;
                }
            }
        }

    /// <summary>
    /// Конструктор класса ProcessBehavior.
    /// Производит запуск таймера проверки жизни процесса.
    /// </summary>
    /// <param name="nameProcess">Имя процесса, за которым будет следить Visor</param>
    /// <param name="processLife">Сколько минут должен существовать процесс</param>
    /// <param name="frequencyChek">Интервал времени проверки жизни процесса в минутах</param>
    public ProcessBehavior(string nameProcess, int processLife, int frequencyChek)
        {
        if (Process.GetProcessesByName(nameProcess).Length < 1)
        {
            Console.WriteLine("Процесс с таким именем не найден");
            return;
        }
            _process = Process.GetProcessesByName(nameProcess);
            this.processLife = processLife;
            this.frequencyChek = frequencyChek;
            Timer timeCheckProcess = new Timer(new TimerCallback(CheckProcessLife), null, 0, frequencyChek * 10000);
        }

    /// <summary>
    /// Проверка времени жизни процесса.
    /// Если процесс существует больше указанного времени, то он будет удалён.
    /// </summary>
    /// <param name="obj"></param>
       public void CheckProcessLife(object obj)
        {
            if((DateTime.Now - _process[0].StartTime).Minutes > processLife)
            {
            Log.SaveLogFile("Log.txt", string.Format("{2} {0} - {1}\n", DateTime.Now, _process[0].ProcessName, Log.OpenLogFile("Log.txt")));
                foreach(Process process in _process)
                {
                    process.Kill();
                }
            }
        }

    }


