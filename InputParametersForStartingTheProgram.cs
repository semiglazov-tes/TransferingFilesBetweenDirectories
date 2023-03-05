using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


    internal class InputParametersForStartingTheProgram
    {
        private bool _incorrectInitialConditionForSourceDirectory = true;
        private bool _incorrectInitialConditionForDestinationDirectory = true;
        private bool _incorrectdataReadInterval = true;
        private DirectoryInfo? _pathToSourceDirectory;
        private DirectoryInfo? _pathToDestinationDirectory;
        private uint _dataReadInterval;
        public DirectoryInfo? PathToSourceDirectory
        {
            get
            {
                return _pathToSourceDirectory;
            }
            set
            {
                if (value.Exists == true)
                {
                    _pathToSourceDirectory = value;
                    _incorrectInitialConditionForSourceDirectory = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Проверьте правильность ввода пути к исходному каталогу");
                    Console.ResetColor();
                }
            }
        }
        public DirectoryInfo? PathToDestinationDirectory
        {
            get
            {
                return _pathToDestinationDirectory;
            }
            set
            {
                if (value.Exists == true)
                {
                    _pathToDestinationDirectory = value;
                    _incorrectInitialConditionForDestinationDirectory = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Проверьте правильность ввода пути к каталогу назначения");
                    Console.ResetColor();
                }
            }
        }
        public uint DataReadInterval
        {
            get
            {
                return _dataReadInterval;
            }
            set
            {
                if (value>=0)
                {
                    _dataReadInterval = value;
                    _incorrectdataReadInterval = false;
                }
            }
        }

        public void startCheckInputData()
        {
            Console.Write("Введите путь к исходнному каталогу(source):");
            string? pathToSourceDirectoryString = Console.ReadLine();
            try
            {
                PathToSourceDirectory = new DirectoryInfo(pathToSourceDirectoryString);
            }
            catch (System.ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В поле ввода передана пустая директория.Введите путь к директории для корректной работы программы");
                Console.ResetColor();
            }

            Console.Write("Введите путь к каталогу назначения(target):");
            string? pathToDestinationalDirectoryString = Console.ReadLine();
            try
            {
                PathToDestinationDirectory = new DirectoryInfo(pathToDestinationalDirectoryString);
            }
            catch (System.ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В поле ввода передана пустая директория.Введите путь к директории для корректной работы программы");
                Console.ResetColor();
            }
            Console.Write("Введите интервал чтения данных(значение в секундах):");
            try
            {
                DataReadInterval = Convert.ToUInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("Значение интервала чтения данных должно лежать в диапозоне от 0 до 4294967295 секунд и быть целым числом");
                Console.ResetColor();
            }
        }
        public bool checkIncorrectInitial()
        {
            if(_incorrectInitialConditionForSourceDirectory || _incorrectInitialConditionForDestinationDirectory || _incorrectdataReadInterval == true)
            {
                return true;
            }
            return false;
        }
        public void checkData()
        {
            while (checkIncorrectInitial() == true)
            {
                startCheckInputData();
            }
        }
}
