using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameMove
{
    public interface IConfiguration
    {
        IEnumerable<string> PathsToProcess { get; set; }
        IEnumerable<string> PathsToProcessNoRename { get; set; }
        IEnumerable<string> VideoFileTypeExtensions { get; set; }
    }
}
