using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RenameMove
{
    public interface IRenameMove
    {
        DirectoryInfo _parentDirectory { get; set; }

        //void MoveVideoFileToParentDirectory();
        void RenameVideoFile(IEnumerable<FileInfo> allFiles, bool renameFile);
        void DeleteSubDirectory(DirectoryInfo subdirectory);
        void DeleteUnwantedFiles(IEnumerable<FileInfo> allFiles);
        bool IgnoreSubfolder(MyDirectoryInfo dir);

    }
}
