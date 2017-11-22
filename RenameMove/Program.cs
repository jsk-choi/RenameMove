using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using RenameMove;

namespace RenameMove
{
    class Program
    {
        static void Main(string[] args)
        {
            IMyFileSystem fileSystem = new MyFileSystem();
            IConfiguration configuration = new Configuration();

            string parentDir = configuration.PathsToProcess.First();

            IRenameMove renameMove = new RenameMove(configuration, fileSystem, parentDir);

            var dirs = fileSystem
                .GetSubDirectoriesInDirectory(parentDir)
                .OrderByDescending(x => x.Depth)
                .ThenBy(x => x.DirectoryInfo.FullName);

            foreach (var dir in dirs)
            {
                var files = fileSystem.GetFilesInDirectory(dir.DirectoryInfo);
                renameMove.DeleteUnwantedFiles(files);
                files = fileSystem.GetFilesInDirectory(dir.DirectoryInfo);

                foreach (var file in files)
                {
                    
                }
            }
        }
    }
}
