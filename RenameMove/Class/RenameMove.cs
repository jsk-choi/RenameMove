using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RenameMove
{
    public class RenameMove : IRenameMove, IDisposable
    {
        public string _ignoreFlagSuffix { get; set; }
        public DirectoryInfo _parentDirectory { get; set; }

        private IConfiguration _configuration { get; set; }
        private IMyFileSystem _fileSystem { get; set; }

        public RenameMove(IConfiguration configuration, IMyFileSystem fileSystem, string parentDirectory) {
            _configuration = configuration;
            _fileSystem = fileSystem;
            _parentDirectory = new DirectoryInfo(parentDirectory);
        }

        public void MoveVideoFileToParentDirectory() {
            var videoFiles = _fileSystem
                .GetFilesInDirectory(_parentDirectory);
                //.Where(x => _configuration.VideoFileTypeExtensions.Contains(x.Extension));
        }

        public void DeleteSubDirectory() {
        }

        public void DeleteUnwantedFiles(IEnumerable<FileInfo> allFiles) {

            var unwantedFiles = allFiles
                .Where(x => 
                    !_configuration
                        .VideoFileTypeExtensions
                        .Contains(x.Extension.Replace(".", "")) ||
                    x.Name.ToLower().Replace(x.Extension.ToLower(), "").ToLower().EndsWith("sample")
                );

            foreach (var unwantedFile in unwantedFiles)
                File.Delete(unwantedFile.FullName);

        }

        public bool IgnoreSubfolder() {
            return true;
        }

        public void Dispose() { }
    }
}
