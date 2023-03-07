using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

internal class TrasferingFiles
{
    // поле принимающее класс, содержащий параметры работы программы
    private InputParametersForStartingTheProgram _inputParametr;
    // поле которое хранит объем скопированных данных
    private long _amountOfDataCopied;
    // свойство реализующее установку значения _inputParametr
    public InputParametersForStartingTheProgram InputParametr { set { _inputParametr = value; } }
    // метод реализующий основную логику программы- копирование файлов из папки Source в папку Target 
    public void copyingFiles()
    {
        while (true)
        {
            //проверяем есть ли в папке Target файлы.При наличии файлов процесс протекает дальше
            if (_inputParametr.PathToSourceDirectory.GetFiles().Length > 0)
            {
                //проходим циклом по файлам в папке Source
                foreach (FileInfo file in _inputParametr.PathToSourceDirectory.GetFiles())
                {
                    string outputFile = Path.Combine(_inputParametr.PathToDestinationDirectory.ToString(), file.Name);
                    try
                    {
                        //на каждой итерации цикла проверяем, копировался ли данный файл из папки Source в папку Target. Если не копировался- осуществляем копирование 
                        if (!File.Exists(outputFile))
                        {
                            //Запускаем пул потоков для копирования файлов в многопоточном режиме.Количество потоков в пуле установили в конструкторе класса TrasferingFiles
                            ThreadPool.QueueUserWorkItem(state =>
                            {
                                file.CopyTo(outputFile, true);
                                //eсли установлен флаг NeedToShowFilesInConsole, то выводим информацию о скопированных файлах на консоль
                                if (_inputParametr.NeedToShowFilesInConsole == true)
                                {
                                    Console.WriteLine($"Произведено копирование файла {file.Name} из папки {_inputParametr.PathToSourceDirectory.Name} в папку {_inputParametr.PathToDestinationDirectory.Name}");
                                }
                                //eсли установлен флаг NeedCountTheAmountOfCopiedData, то производим подсчет объема скопированных файлов
                                if (_inputParametr.NeedCountTheAmountOfCopiedData == true)
                                {
                                    _amountOfDataCopied += file.Length;
                                    Console.WriteLine($"Объем скопированных данных:{_amountOfDataCopied} байт");
                                }
                                //проверяем стоит ли флаг о необходимости удаления файлов из папки Source после копирования
                                if (_inputParametr.NeedToDeleteFiles == true)
                                {
                                    file.Delete();
                                }
                            });
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Ошибка в копировании файла {file.Name}.Причина ошибки{ex.Message}");
                    }
                }
            }
            //реализуем интервал чтения данных из папки Source 
            Thread.Sleep((int)_inputParametr.DataReadInterval * 1000);
        }
    }
    //конструктор класса TrasferingFiles
    public TrasferingFiles(InputParametersForStartingTheProgram inputParametr)
    {
        InputParametr=inputParametr;
        ThreadPool.SetMaxThreads((int)_inputParametr.NumberOfThreads,(int)_inputParametr.NumberOfThreads);
    }
}

