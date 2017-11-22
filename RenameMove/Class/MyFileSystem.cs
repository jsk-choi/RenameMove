using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameMove
{
    public class MyFileSystem : IMyFileSystem
    {
        readonly IFileSystem _fileSystem;
        public string _ignoreFlagSuffix { get; set; }

        public MyFileSystem(IFileSystem fileSystem) {
            _fileSystem = fileSystem;
        }

        public MyFileSystem() : this(
            fileSystem: new FileSystem())
        {
        }

        public IEnumerable<FileInfo> GetFilesInDirectory(string directoryPath)
        {
            return GetFilesInDirectory(new DirectoryInfo(directoryPath));
        }
        public IEnumerable<FileInfo> GetFilesInDirectory(DirectoryInfo directoryInfo) {
            return Directory
                .GetFiles(directoryInfo.FullName, "*.*", SearchOption.AllDirectories)
                .Select(x => new FileInfo(x));
        }

        public IEnumerable<MyDirectoryInfo> GetSubDirectoriesInDirectory(string directoryPath)
        {
            return GetSubDirectoriesInDirectory(new DirectoryInfo(directoryPath));
        }
        public IEnumerable<MyDirectoryInfo> GetSubDirectoriesInDirectory(DirectoryInfo directoryInfo)
        {
            return Directory
                .GetDirectories(directoryInfo.FullName, "*.*", SearchOption.AllDirectories)
                .Where(x => !x.ToLower().Contains(_ignoreFlagSuffix))
                .Select(x => new MyDirectoryInfo(x));
        }
    }
}
