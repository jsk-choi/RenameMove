using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;

namespace RenameMove
{
    public class MyDirectoryInfo
    {
        public MyDirectoryInfo(string path) {
            DirectoryInfo = new DirectoryInfo(path);
            Depth = DirectoryInfo.FullName.Split(Path.DirectorySeparatorChar).Count();
        }

        public DirectoryInfo DirectoryInfo { get; set; }
        public int Depth { get; set; }
    }
}
