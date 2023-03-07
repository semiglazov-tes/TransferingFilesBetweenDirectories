//Создаем экземляр класс InputParametersForStartingTheProgram, который производит прием параметров программы с консоли и проводит их валидацию
InputParametersForStartingTheProgram checkInputParameters = new InputParametersForStartingTheProgram();
checkInputParameters.startCheckInputData();

//Создаем экземляр класс copyingFilesApp, реализующий основной функционал программы
TrasferingFiles copyingFilesApp = new TrasferingFiles(checkInputParameters);
copyingFilesApp.copyingFiles();