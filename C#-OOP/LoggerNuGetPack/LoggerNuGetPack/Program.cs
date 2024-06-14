using SimpleLogger.Core.Appenders;
using SimpleLogger.Core.Appenders.Interfaces;
using SimpleLogger.Core.IO;
using SimpleLogger.Core.Layouts;
using SimpleLogger.Core.Layouts.Interfaces;
using SimpleLogger.Core.Loggers;
using SimpleLogger.Core.Loggers.Interfaces;

ILayout simpleLayout = new SimpleLayout();
IAppender consoleAppender = new ConsoleAppender(simpleLayout);
var file = new LogFile();
var fileAppender = new FileAppender(simpleLayout, file);

ILogger logger = new Logger(consoleAppender, fileAppender);




logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
