using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameMove
{
    public interface IMyFileSystem
    {
        IEnumerable<FileInfo> GetFilesInDirectory(string directoryPath);
        IEnumerable<FileInfo> GetFilesInDirectory(DirectoryInfo directoryInfo);
        IEnumerable<MyDirectoryInfo> GetSubDirectoriesInDirectory(string directoryPath);
        IEnumerable<MyDirectoryInfo> GetSubDirectoriesInDirectory(DirectoryInfo directoryInfo);
    }
}
