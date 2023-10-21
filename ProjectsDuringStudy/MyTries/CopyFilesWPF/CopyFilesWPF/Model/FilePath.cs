using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFilesWPF.Model
{
    public sealed record FilePath
    {
        private string? _pathTo { get; set; }

        public string PathFrom { get; set; }

        public string PathTo 
        { 
            get => _pathTo + "\\" + Path.GetFileName(PathFrom); 
            set => _pathTo = value;
        }
    }
}
