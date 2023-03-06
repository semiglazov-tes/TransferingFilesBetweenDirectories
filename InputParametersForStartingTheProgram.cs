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
        //флаг указывающий, что ввод количества потоков введено некоректно
        private bool _incorrectNumberOfThreads = true;
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
        // флаг указывающий, необходимоcть удаления файлов из папки Source после копирования
        private bool _needToDeleteFiles;
        // флаг указывающий, необходимоcть вывода коприруемых файлов на экран
        private bool _needToShowFilesInConsole;
        // флаг указывающий, необходимоcть считать объем скопированных данных
        private bool _needCountTheAmountOfCopiedData;
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
        // свойство реализующее установку/получение значения _numberOfThreads
        public uint NumberOfThreads
        {
            get
            {
                return _numberOfThreads;
            }
            set
            {
                if(value != 0)
                {
                    _numberOfThreads = value;
                    _incorrectNumberOfThreads = false;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Количество потоков не может равным 0");
                    Console.ResetColor();
                }
            }
        }
         // свойство реализующее установку/получение значения _needToDeleteFiles
        public bool NeedToDeleteFiles 
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
        // свойство реализующее установку/получение значения _needToShowFilesInConsole 
        public bool NeedToShowFilesInConsole
    {
            get
            {
                return _needToShowFilesInConsole;
            }
            set
            {
                _needToShowFilesInConsole = value;
            }
        }
        // свойство реализующее установку/получение значения _needCountTheAmountOfCopiedData
        public bool NeedCountTheAmountOfCopiedData
    {
            get
            {
                return _needCountTheAmountOfCopiedData;
            }
            set
            {
                _needCountTheAmountOfCopiedData = value;
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
                SettingAdditionalParameters = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            }
                catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("Значение выбирается из следующих:1-да/0-нет");
                Console.ResetColor();
            }
            if (SettingAdditionalParameters == true) 
            {
                Console.Write("Введите количество потоков копирования данных:");
                try
                {
                    NumberOfThreads = Convert.ToUInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Значение количества потоков копирования данных должно быть целым положительным числом");
                    Console.ResetColor();
                }
                Console.Write("Удалять файлы из папки Source после копирования?(1-да/0-нет):");
                try
                {
                    NeedToDeleteFiles = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Значение выбирается из следующих:1-да/0-нет");
                    Console.ResetColor();
                }
                Console.Write("Выводить на консоль копируемые файлы?(1-да/0-нет):");
                try
                {
                    NeedToShowFilesInConsole = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Значение выбирается из следующих:1-да/0-нет");
                    Console.ResetColor();
                }
                Console.Write("Производить вычисление объема копируемыех файлов?(1-да/0-нет):");
                try
                {
                    NeedCountTheAmountOfCopiedData = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Значение выбирается из следующих:1-да/0-нет");
                    Console.ResetColor();
                }
            }
        }
        // методы, проверяющие все ли параметры запуска программы введены корректно
        public bool checkIncorrectInitial()
        {
            if(_incorrectInitialConditionForSourceDirectory || _incorrectInitialConditionForDestinationDirectory || _incorrectdataReadInterval == true )
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
