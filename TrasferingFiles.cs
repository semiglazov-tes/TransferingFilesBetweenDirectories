using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.IO;

internal class TrasferingFiles{

    private bool _endProgramFlag=false;
    private bool _correctInitialCondition = false;
    private DirectoryInfo? _pathToSourceDirectory;
    private DirectoryInfo? _pathToDestinationDirectory;
    public bool EndProgramFlag { get; set; }
    public bool CorrectInitialCondition { get; set; }
    public DirectoryInfo? PathToSourceDirectory{
        get{
           return _pathToSourceDirectory;
        }
        set{
            if(value != null && value.Exists == true){
                _pathToDestinationDirectory = value;
                CorrectInitialCondition = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Проверьте правильность ввода пути к исходному каталогу");
                Console.ResetColor();
            }
        }
    }
    public DirectoryInfo? PathToDestinationDirectory
    {
        get
        {
            return _pathToSourceDirectory;
        }
        set
        {
            if (value != null && value.Exists == true) {
                _pathToDestinationDirectory = value;
                CorrectInitialCondition = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Проверьте правильность ввода пути к каталогу назначения");
                Console.ResetColor();
            }
        }
    }

    public void startProgram() {
        Console.Write("Введите путь к исходному каталогу:");
        string? pathToSourceDirectoryString = Console.ReadLine();
        PathToSourceDirectory = new DirectoryInfo(pathToSourceDirectoryString);

        Console.Write("Введите путь к исходному каталогу:");
        string? pathToDestinationalDirectoryString = Console.ReadLine();
        PathToDestinationDirectory = new DirectoryInfo(pathToDestinationalDirectoryString);
    }
    public void copyingFiles() {
        
    }
    /*public TrasferingFiles(DirectoryInfo? pathToSourceDirectory, DirectoryInfo? pathToDestinationalDirectory)
        {
            
        }
    }*/
}

