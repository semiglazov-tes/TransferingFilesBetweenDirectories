using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.IO;

internal class TrasferingFiles{

    private DirectoryInfo? _pathToSourceDirectory;
    private DirectoryInfo? _pathToDestinationDirectory;
    public DirectoryInfo? PathToSourceDirectory{
        get{
           return _pathToSourceDirectory;
        }
        set{
            if(value != null && value.Exists == true){
                _pathToDestinationDirectory = value;
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
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Проверьте правильность ввода пути к каталогу назначения");
                Console.ResetColor();
            }
        }
    }

    public void startProgam() {

    }
    /*public TrasferingFiles(DirectoryInfo? pathToSourceDirectory, DirectoryInfo? pathToDestinationalDirectory)
        {
            
        }
    }*/
}

