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
        string _ignoreFlagSuffix { get; set; }
        DirectoryInfo _parentDirectory { get; set; }

        void MoveVideoFileToParentDirectory();
        void DeleteSubDirectory();
        void DeleteUnwantedFiles(IEnumerable<FileInfo> allFiles);
        bool IgnoreSubfolder();

    }
}
