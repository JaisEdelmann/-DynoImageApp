using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DynoImageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder                      = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            SetupConsole();

            var repository                 = new Repositories.dbRepository();
            var processService             = new Services.ProcessService();
            var imageService               = new Services.ImageService();

            var dbModel                    = repository.ReadDb();
            var lastexecution              = DateTime.UtcNow;
            var images                     = processService.GetImages(configuration);

            imageService.ProcessImageList(images, configuration);
            dbModel.LastExecutionTime = lastexecution;
            repository.UpdateDb(dbModel);

        }

        private static void SetupConsole()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"     ____.___________                       _____                                                ");
            Console.WriteLine(@"    |    |\_   _____/ ______   ____________/ ____\___________  _____ _____    ____   ____  ____  ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"    |    | |    __)_  \____ \_/ __ \_  __ \   __\/  _ \_  __ \/     \\__  \  /    \_/ ___\/ __ \ ");
            Console.WriteLine(@"/\__|    | |        \ |  |_> >  ___/|  | \/|  | (  <_> )  | \/  Y Y  \/ __ \|   |  \  \__\  ___/ ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"\________|/_______  / |   __/ \___  >__|   |__|  \____/|__|  |__|_|  (____  /___|  /\___  >___  >");
            Console.WriteLine(@"                  \/  |__|        \/                               \/     \/     \/     \/    \/ ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("JE Performance - Watermark dyno tool!");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
    }
}
