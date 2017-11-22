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
        public DirectoryInfo _parentDirectory { get; set; }

        private IConfiguration _configuration { get; set; }
        private IMyFileSystem _fileSystem { get; set; }

        public RenameMove(IConfiguration configuration, IMyFileSystem fileSystem) {
            _configuration = configuration;
            _fileSystem = fileSystem;
        }

        public void MoveVideoFileToParentDirectory() {
            var videoFiles = _fileSystem
                .GetFilesInDirectory(_parentDirectory);
                //.Where(x => _configuration.VideoFileTypeExtensions.Contains(x.Extension));
        }

        public void DeleteSubDirectory(DirectoryInfo subdirectory)
        {
            Directory.Delete(subdirectory.FullName, true);
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

        public void RenameVideoFile(IEnumerable<FileInfo> allFiles) {

            foreach (var file in allFiles)
            {
                int counter = 0;
                string uniqueId = "";

                var dirInfo = new DirectoryInfo(file.FullName);
                var destinationFileName = $"{dirInfo.Parent.FullName}{file.Extension}";

                while (File.Exists(destinationFileName)) {

                    uniqueId = $"-{counter}";
                    destinationFileName = $"{dirInfo.Parent.FullName}{uniqueId}{file.Extension}";

                    counter++;
                }

                File.Move(file.FullName, destinationFileName);
            }

        }

        public bool IgnoreSubfolder() {
            return true;
        }

        public void Dispose() { }
    }
}
