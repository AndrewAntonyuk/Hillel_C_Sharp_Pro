using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiaOpennessHelper.Utils;

namespace TestOpenessVS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AssemblySelection());
        }


        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            int index = args.Name.IndexOf(',');
            if (index == -1)
            {
                return null;
            }
            string name = args.Name.Substring(0, index) + ".dll";
            // Edit the following path according to your installed version of TIA Portal
            string path = Path.Combine(@"C:\Program Files\Siemens\Automation\Portal V17\PublicAPI\V17\", name);
            string fullPath = Path.GetFullPath(path);
            if (File.Exists(fullPath))
            {
                return Assembly.LoadFrom(fullPath);
            }
            return null;



            /* var executingAssembly = Assembly.GetExecutingAssembly();
             var assemblyName = new AssemblyName(args.Name);

             var path = assemblyName.Name + ".dll";
             if (assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) == false)
             {
                 path = string.Format(CultureInfo.InvariantCulture, @"{0}\{1}", assemblyName.CultureInfo, path);
             }

             using (var stream = executingAssembly.GetManifestResourceStream(path))
             {
                 if (stream == null)
                     return null;

                 var assemblyRawBytes = new byte[stream.Length];
                 stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
                 return Assembly.Load(assemblyRawBytes);
             }
            */
        }


        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;

            System.Windows.MessageBox.Show(ex.Message);
        }

    }
}
