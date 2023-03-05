using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

internal class TrasferingFiles
{
    private InputParametersForStartingTheProgram _inputParametr;
    private bool _endProgramFlag = false;
    private Thread _copyingThread;
    private HashSet<FileInfo> _listOfFilesInTheCurrentIteratuion;
    private HashSet<FileInfo> _listOfFilesInThePreviousIteratuion;
    public InputParametersForStartingTheProgram InputParametr { set { _inputParametr = value; } }
    public bool EndProgramFlag {get; set;}
    public void startThreadCopying()
    {
        _copyingThread = new Thread(copyingFiles);
        _copyingThread.Start();
    }

    public void copyingFiles() 
    {
        while (_endProgramFlag== false)
        {
            if (_inputParametr.PathToSourceDirectory.GetFiles().Length > 0)
            {
                _listOfFilesInTheCurrentIteratuion = new HashSet<FileInfo>(_inputParametr.PathToSourceDirectory.GetFiles());
                _listOfFilesInThePreviousIteratuion = new HashSet<FileInfo>(_inputParametr.PathToDestinationDirectory.GetFiles());
                _listOfFilesInTheCurrentIteratuion.ExceptWith(_listOfFilesInThePreviousIteratuion);
                foreach (FileInfo file in _listOfFilesInTheCurrentIteratuion)
                {
                    string outputFile = Path.Combine(_inputParametr.PathToDestinationDirectory.ToString(), file.Name);
                    try
                    {
                        file.CopyTo(outputFile, true);
                        Console.WriteLine($"Произведено копирование файла {file.Name} из папки {_inputParametr.PathToSourceDirectory.Name} в папку {_inputParametr.PathToDestinationDirectory.Name}");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Ошибка в копировании файла {file.Name}.Причина ошибки{ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Исходная папка пуста");
            }
            Thread.Sleep((int)_inputParametr.DataReadInterval * 1000);
            //EndProgramFlag = true;
        }
    }
    public TrasferingFiles(InputParametersForStartingTheProgram inputParametr)
    {
        InputParametr=inputParametr;
    }
    
}

