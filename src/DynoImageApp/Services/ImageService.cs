using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace DynoImageApp.Services
{
    class ImageService : Interfaces.IImageService
    {
        public void ProcessImageList(IEnumerable<FileInfo> images, IConfiguration configuration)
        {
            var i = 0;
            var total = images.ToList().Count;
            foreach(var image in images)
            {
                i++;
                Console.WriteLine($"Processing '{i}' of {total} images");
                ProcessImageList(image, new FileInfo(configuration["watermarkPath"]), configuration);
            }
        }

        private void ProcessImageList(FileInfo image, FileInfo watermark, IConfiguration configuration)
        {
            var outputFilePath = configuration["outputFolder"] + @"\" + Path.GetFileName(image.FullName).Replace(image.Extension,"" + ".png");
            Image backImg      = Image.FromFile(image.FullName);
            Image mrkImg       = Image.FromFile(watermark.FullName);
            Graphics g         = Graphics.FromImage(backImg);
            g.DrawImage(mrkImg,0,0);
            backImg.Save(outputFilePath);
        }   
    }
}
