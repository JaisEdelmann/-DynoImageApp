using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DynoImageApp.Services
{
    public class ProcessService : Interfaces.IProcessService
    {
        public IEnumerable<FileInfo> GetImages(IConfiguration configuration)
        {

            var result = new List<FileInfo>();
            var dbrepository = new Repositories.dbRepository();

            var files = Directory.GetFiles(configuration["inputFolder"], configuration["fileextension"], SearchOption.AllDirectories).ToList();
            Console.WriteLine($"Found '{files.Count}' images to process.");
            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                if(fi.LastWriteTime > dbrepository.ReadDb().LastExecutionTime)
                {
                    Console.WriteLine($"Adding file: '{Path.GetFileNameWithoutExtension(fi.FullName)}'");
                    result.Add(fi);
                }
                else
                {
                    Console.WriteLine($"Skipping file, as this has already been processed since last exectuion: '{Path.GetFileNameWithoutExtension(fi.FullName)}' ");
                }
            }

            return result;
        }
    }
}
