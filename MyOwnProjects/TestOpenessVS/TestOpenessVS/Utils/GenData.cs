using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOpenessVS.Utils
{
    public class GenData
    {
        public GenData()
        {
            _workingDirectory  = Environment.CurrentDirectory;
            _defaultExportFolderPath = Directory.GetParent(_workingDirectory).Parent.FullName + "\\ExpFolder";
            _defaultImportFolderPath = Directory.GetParent(_workingDirectory).Parent.FullName + "\\ImpFolder";
        }
        public static string _workingDirectory { get; set; }   // = Environment.CurrentDirectory;

        public string _defaultExportFolderPath { get; set; }   // = Directory.GetParent(_workingDirectory).Parent.FullName + "\\ExpFolder";

        public string _defaultImportFolderPath { get; set; }   // = Directory.GetParent(_workingDirectory).Parent.FullName + "\\ImpFolder";
    }
}
