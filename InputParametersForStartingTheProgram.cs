using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


    internal class InputParametersForStartingTheProgram
    {
        //флаг указывающий, что ввод пути к папке Source некоректен
        private bool _incorrectInitialConditionForSourceDirectory = true;
        //флаг указывающий, что ввод пути к папке Tagert некоректен
        private bool _incorrectInitialConditionForDestinationDirectory = true;
        //флаг указывающий, что ввод интервала чтения данных некоректен
        private bool _incorrectdataReadInterval = true;
        // поле принимающее папку Source
        private DirectoryInfo? _pathToSourceDirectory;
        // поле принимающее папку Tagert
        private DirectoryInfo? _pathToDestinationDirectory;
        // поле принимающее интервал чтения данных
        private uint _dataReadInterval;
        // флаг указывающий, необходимо задание опциональных параметров или нет
        private bool _settingAdditionalParameters;
        // количество потоков копирования данных
        private uint _numberOfThreads=1;
        // свойство реализующее установку/получение значения _pathToSourceDirectory 
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
        // свойство реализующее установку/получение значения _pathToDestinationDirectory 
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
        // свойство реализующее установку/получения значения _dataReadInterval
        public uint DataReadInterval
        {
            get
            {
                return _dataReadInterval;
            }
            set
            {
                _dataReadInterval = value;
                _incorrectdataReadInterval = false;
            }
        }
        // свойство реализующее установку/получение значения _settingAdditionalParameters
        public bool SettingAdditionalParameters 
        {
            get
            {
                return _settingAdditionalParameters;
            }
            set
            {
            _settingAdditionalParameters = value;

            }
    }
        // метод, который принимает параметры запуска программы с консоли и обрабатывает исключения, возникающие при некорректном вводе параметров
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
            Console.Write("Задать опциональные параметры работы программы(1-да/0-нет):");
            try
            {
                SettingAdditionalParameters = Convert.ToBoolean(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("Значение параметра должно быть равным:1(при необходимости задания дополнительных парамметров программы) или 0(если задание дополнительных парамметров программы не требуется");
                Console.ResetColor();
            }
            if (SettingAdditionalParameters == true) 
            {
                Console.Write("Введите количество потоков копирования данных:");
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
        }
        // методы, проверяющие все ли параметры запуска программы введены корректно
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
