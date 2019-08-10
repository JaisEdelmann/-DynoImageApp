using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynoImageApp.Interfaces
{
    public interface IProcessService
    {
        IEnumerable<FileInfo> GetImages(IConfiguration configuration);
    }
}
