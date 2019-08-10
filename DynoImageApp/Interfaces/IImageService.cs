using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynoImageApp.Interfaces
{
    interface IImageService
    {
        void ProcessImageList(IEnumerable<FileInfo> images, IConfiguration configuration);
    }
}
