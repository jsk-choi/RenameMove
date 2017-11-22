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
                ProcessAllLocations(path, configuration);

            foreach (var path in configuration.PathsToProcessNoRename)
                ProcessAllLocations(path, configuration, false);
        }

        static void ProcessAllLocations(string path, IConfiguration configuration, bool renameFile = true) {

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
                if (renameMove.IgnoreSubfolder(dir)) continue;

                // RETRIEVE ALL FILES IN SUBDIRECTORY
                files = fileSystem.GetFilesInDirectory(dir.DirectoryInfo);

                // DELETE ANYTHING NOT VIDEO FILE
                renameMove.DeleteUnwantedFiles(files);

                // RETRIEVE ALL VIDEO FILES IN SUBDIRECTORY
                files = fileSystem.GetFilesInDirectory(dir.DirectoryInfo);

                // RENAME VIDEO FILE TO DIRECTORY NAME AND MOVE TO PARENT
                renameMove.RenameVideoFile(files, renameFile);

                // DELETE SUBDIRECTORY
                renameMove.DeleteSubDirectory(dir.DirectoryInfo);
            }
        }
    }
}
