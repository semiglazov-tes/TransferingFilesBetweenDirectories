
InputParametersForStartingTheProgram checkInputParameters = new InputParametersForStartingTheProgram();
checkInputParameters.checkData();

TrasferingFiles copyingFilesApp = new TrasferingFiles(checkInputParameters);
copyingFilesApp.startThreadCopying();