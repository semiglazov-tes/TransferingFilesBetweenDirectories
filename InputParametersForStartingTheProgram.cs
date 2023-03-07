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
        //флаг указывающий, что ввод необходимости опциональных параметров не верен
        private bool _incorrectsettingAdditionalParameters = true;
        //флаг указывающий, что ввод количества потоков введено некоректно _numberOfThreads
        private bool _incorrectNumberOfThreads = true;
        //флаг указывающий, что выбрано некорректное значение для _needToDeleteFiles  
        private bool _incorrectNeedToDeleteFiles = true;
        //флаг указывающий, что выбрано некорректное значение для _needToShowFilesInConsole  
        private bool _incorrectNeedToShowFilesInConsole = true;
        //флаг указывающий, что выбрано некорректное значение для _needCountTheAmountOfCopiedData  
        private bool _incorrectNeedCountTheAmountOfCopiedData = true;
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
                    Console.Write("Каталог по заданному пути отсутствует");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();
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
                    Console.Write("Каталог по заданному пути отсутствует");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();
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
                _incorrectsettingAdditionalParameters = false;
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
                    Console.Write("Количество потоков не может равным 0");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
         // свойство реализующее установку/получение значения _needToDeleteFiles
        public bool NeedToDeleteFiles 
        {
            get
            {
                return _needToDeleteFiles;
            }
            set
            {
                _needToDeleteFiles = value;
                _incorrectNeedToDeleteFiles = false;
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
                _incorrectNeedToShowFilesInConsole = false;
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
                _incorrectNeedCountTheAmountOfCopiedData = false;
            }
        }
        
        // метод, который принимает параметры запуска программы с консоли и обрабатывает исключения, возникающие при некорректном вводе параметров
        public void startCheckInputData()
        {
            while (_incorrectInitialConditionForSourceDirectory == true)
            {
                Console.Write("Введите путь к исходнному каталогу(source):");
                string pathToSourceDirectoryString = Console.ReadLine();
                Console.Clear();
                try
                {
                    PathToSourceDirectory = new DirectoryInfo(pathToSourceDirectoryString);
                }
                catch (Exception)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Путь к каталогу не может быть пустой строкой");
                Console.ResetColor();
                Thread.Sleep(2000);
                Console.Clear();
                }
            }
            while (_incorrectInitialConditionForDestinationDirectory==true)
            {
                Console.Write("Введите путь к каталогу назначения(target):");
                string pathToDestinationalDirectoryString = Console.ReadLine();
                Console.Clear();
            try
            {
                if (PathToSourceDirectory.FullName== pathToDestinationalDirectoryString)
                {
                    throw new Exception();
                }
                PathToDestinationDirectory = new DirectoryInfo(pathToDestinationalDirectoryString);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Путь к каталогу не может быть пустой строкой.Путь к папке Tagert не должен совпадать с Source");
                Console.ResetColor();
                Thread.Sleep(2000);
                Console.Clear();
            }
            }   
            while (_incorrectdataReadInterval==true)
            {
                Console.Write("Введите интервал чтения данных(значение в секундах):");
                try
                {
                    DataReadInterval = Convert.ToUInt32(Console.ReadLine());
                    Console.Clear();
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Значение интервала чтения данных должно лежать в диапозоне от 0 до 4294967295 секунд и быть целым числом");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            while (_incorrectsettingAdditionalParameters == true)
            {
                Console.Write("Задать опциональные параметры работы программы(1-да/0-нет):");
                string inputSettingAdditional= Console.ReadLine();
                Console.Clear();
                try
                {   
                    switch (inputSettingAdditional)
                    {
                        case "1":
                          SettingAdditionalParameters =true;
                          break;
                        case "0":
                          SettingAdditionalParameters = false;
                          break;
                        default:
                            throw new Exception();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Значение флага должно иметь одно из следующих значений:1-да/0-нет");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            if (SettingAdditionalParameters == true) 
            {
                while (_incorrectNumberOfThreads==true)
                {
                    Console.Write("Введите количество потоков копирования данных:");
                    try
                    {
                        NumberOfThreads = Convert.ToUInt32(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Значение количества потоков копирования данных должно быть целым положительным числом");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                while (_incorrectNeedToDeleteFiles==true)
                {
                    Console.Write("Удалять файлы из папки Source после копирования?(1-да/0-нет):");
                    string inputNeedToDeleteFiles= Console.ReadLine();
                    Console.Clear();
                    try
                    {
                        switch (inputNeedToDeleteFiles)
                        {
                            case "1":
                            NeedToDeleteFiles =true;
                            break;
                            case "0":
                            NeedToDeleteFiles = false;
                            break;
                            default:
                                throw new Exception();
                                break;
                        }   
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Значение выбирается из следующих:1-да/0-нет");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                while (_incorrectNeedToShowFilesInConsole==true)
                {
                    Console.Write("Выводить на консоль копируемые файлы?(1-да/0-нет):");
                    string inputNeedToShowFilesInConsole = Console.ReadLine();
                    Console.Clear();
                    try
                    {
                        switch (inputNeedToShowFilesInConsole)
                        {
                            case "1":
                                NeedToShowFilesInConsole = true;
                                break;
                            case "0":
                                NeedToShowFilesInConsole = false;
                                break;
                            default:
                                throw new Exception();
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Значение выбирается из следующих:1-да/0-нет");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                while (_incorrectNeedCountTheAmountOfCopiedData==true)
                {
                    Console.Write("Производить вычисление объема копируемыех файлов?(1-да/0-нет):");
                    string inputNeedCountTheAmountOfCopiedData = Console.ReadLine();
                    
                    try
                    {
                        switch (inputNeedCountTheAmountOfCopiedData)
                        {
                            case "1":
                                NeedCountTheAmountOfCopiedData = true;
                                break;
                            case "0":
                                NeedCountTheAmountOfCopiedData = false;
                                break;
                            default:
                                throw new Exception();
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Значение выбирается из следующих:1-да/0-нет");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
            }
        }
    }
