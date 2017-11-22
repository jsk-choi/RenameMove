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
            IConfiguration configuration = new Configuration();

            foreach (var path in configuration.PathsToProcess)
            {
                ProcessAllLocations(path, configuration);
            }
        }

        static void ProcessAllLocations(string path, IConfiguration configuration) {

            IMyFileSystem fileSystem = new MyFileSystem();
            fileSystem._ignoreFlagSuffix = "zz";

            IRenameMove renameMove = new RenameMove(configuration, fileSystem);

            // RETRIEVE ALL SUBDIRECTORIES
            var dirs = fileSystem
                .GetSubDirectoriesInDirectory(path)
                .OrderByDescending(x => x.Depth)
                .ThenBy(x => x.DirectoryInfo.FullName);

            IEnumerable<FileInfo> files;

            foreach (var dir in dirs)
            {
                // RETRIEVE ALL FILES IN SUBDIRECTORY
                files = fileSystem.GetFilesInDirectory(dir.DirectoryInfo);

                // DELETE ANYTHING NOT VIDEO FILE
                renameMove.DeleteUnwantedFiles(files);

                // RETRIEVE ALL VIDEO FILES IN SUBDIRECTORY
                files = fileSystem.GetFilesInDirectory(dir.DirectoryInfo);

                // RENAME VIDEO FILE TO DIRECTORY NAME AND MOVE TO PARENT
                renameMove.RenameVideoFile(files);

                // DELETE SUBDIRECTORY
                renameMove.DeleteSubDirectory(dir.DirectoryInfo);
            }
        }
    }
}
