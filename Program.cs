
TrasferingFiles app = new TrasferingFiles();

Console.Write("Введите путь к исходному каталогу:");
string pathToSourceDirectoryString = Console.ReadLine();
DirectoryInfo pathToSourceDirectory  = new DirectoryInfo(pathToSourceDirectoryString);

Console.Write("Введите путь к исходному каталогу:");
string pathToDestinationalDirectoryString = Console.ReadLine();
DirectoryInfo pathToDestinationalDirectory = new DirectoryInfo(pathToDestinationalDirectoryString);

