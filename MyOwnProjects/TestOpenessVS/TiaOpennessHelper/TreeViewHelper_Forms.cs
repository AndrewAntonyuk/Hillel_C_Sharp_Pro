using System;
using System.Windows.Forms;
using Siemens.Engineering;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.Hmi.Cycle;
using Siemens.Engineering.HW;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.SW;

namespace TiaOpennessHelper
{
    /// <summary>
    /// Helper Class to retrive projektnavigation as TreeNode
    /// </summary>
    public class OpennessTreeViewsForms
    {
        /// <summary>
        /// Adds all objects in the provided folder as TreeViewItems to the provided treeViewItem
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <param name="treeViewItem">The tree view item.</param>
        private static void RecursiveGetTreeView(IEngineeringInstance folder, ref TreeNode treeViewItem)
        {
            treeViewItem.Name = OpennessHelper.GetObjectName(folder);
            treeViewItem.Text = OpennessHelper.GetObjectName(folder);
            treeViewItem.Tag = folder;

            foreach (var item in OpennessHelper.GetSubItem(folder))
            {
                var sub = new TreeNode();
                sub.Name = OpennessHelper.GetObjectName(item as IEngineeringInstance);
                sub.Text = OpennessHelper.GetObjectName(item as IEngineeringInstance);
                sub.Tag = item;

                if (!(item is Cycle && (item as Cycle).IsSystemObject))
                    treeViewItem.Nodes.Add(sub);
            }

            foreach (var subfolder in OpennessHelper.GetSubFolder(folder))
            {
                var subView = new TreeNode();
                RecursiveGetTreeView(subfolder as IEngineeringInstance, ref subView);
                treeViewItem.Nodes.Add(subView);
            }
        }

        /// <summary>Returns a TreeNode of the objects in the IDeviceItem</summary>
        /// <param name="item">The item.</param>
        /// <returns>TreeNode</returns>
        private static TreeNode RecursiveGetDevicesTreeView(DeviceItem item)
        {
            var treeViewItem = new TreeNode();
            treeViewItem.Name = item.Name;
            treeViewItem.Text = item.Name;
            treeViewItem.Tag = item;

            //if (item.Subtype.ToLowerInvariant().Contains("sinamics"))
            //    return treeViewItem;

            //if (item.Addresses != null)
            //{
            //    foreach (var adr in item.Addresses)
            //    {
            //        treeViewItem.Nodes.Add(new TreeNode
            //        {
            //            Header = adr.ToString(),
            //            Tag = adr
            //        });
            //    }
            //}

            //IInterface itf = ((IEngineeringServiceProvider)item).GetService<IInterface>();
            //if (itf != null)
            //{
            //    foreach (var node in itf.Nodes)
            //    {
            //        treeViewItem.Nodes.Add(new TreeNode
            //        {
            //            Header = node.NodeId,
            //            Tag = node
            //        });
            //    }
            //}

            foreach (var subItem in item.DeviceItems)
            {
                var temp = RecursiveGetDevicesTreeView(subItem);
                if (temp != null)
                    treeViewItem.Nodes.Add(temp);
            }

            return treeViewItem;
        }

        /// <summary>Returns a TreeView of the hardware</summary>
        /// <param name="station">The station.</param>
        /// <returns>TreeNode</returns>
        public static TreeNode GetHardwareTreeView(Device station)
        {
            var item = new TreeNode();
            item.Name = station.Name;
            item.Text = station.Name;
            item.Tag = station;

            //if (station.TypeIdentifier.ToLower().Contains("sinamics"))
            //    return item;

            foreach (var subItem in station.DeviceItems)
            {
                item.Nodes.Add(RecursiveGetDevicesTreeView(subItem));
            }
            return item;
        }

        /// <summary>Gets all graphics TreeView.</summary>
        /// <param name="project">The project.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;project</exception>
        /// <exception cref="ArgumentNullException">Parameter is null;project</exception>
        public static TreeNode GetGraphicsTreeView(Project project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(project.Graphics, ref collection);

            return collection;
        }

        /// <summary>
        /// Returns a TreeView of all Programm Blocks in the PlcSoftware
        /// </summary>
        /// <param name="plcSoftware">PlcSoftware to be searched</param>
        /// <returns>TreeView of PlcBlocks</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;PlcSoftware</exception>
        public static TreeNode GetBlocksTreeView(PlcSoftware plcSoftware)
        {
            if (plcSoftware == null)
                throw new ArgumentNullException(nameof(plcSoftware), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(plcSoftware.BlockGroup, ref collection);

            return collection;
        }

        /// <summary>
        /// Returns a TreeView of all PlcTagTables in the PlcSoftware
        /// </summary>
        /// <param name="plcSoftware">PlcSoftware to be searched</param>
        /// <returns>TreeView of ControlerTagTables</returns>
        /// <exception cref="System.ArgumentNullException">PArameter is null;PlcSoftware</exception>
        public static TreeNode GetTagTablesTreeView(PlcSoftware plcSoftware)
        {
            if (plcSoftware == null)
                throw new ArgumentNullException(nameof(plcSoftware), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(plcSoftware.TagTableGroup, ref collection);
            return collection;
        }

        /// <summary>
        /// Returns a TreeView of all WatchAndForceTables in the PlcSoftware
        /// </summary>
        /// <param name="plcSoftware">PlcSoftware to be searched</param>
        /// <returns>TreeView of ControlerWatchAndForceTables</returns>
        /// <exception cref="System.ArgumentNullException">PArameter is null;PlcSoftware</exception>
        public static TreeNode GetWatchAndForceTablesTreeView(PlcSoftware plcSoftware)
        {
            if (plcSoftware == null)
                throw new ArgumentNullException(nameof(plcSoftware), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(plcSoftware.WatchAndForceTableGroup, ref collection);
            return collection;
        }

        /// <summary>
        /// Returns a TreeView of all PlcTypes in the PlcSoftware
        /// </summary>
        /// <param name="plcSoftware">PlcSoftware to be searched</param>
        /// <returns>TreeView of PlcTypes</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;PlcSoftware</exception>
        public static TreeNode GetDatatypesTreeView(PlcSoftware plcSoftware)
        {
            if (plcSoftware == null)
                throw new ArgumentNullException(nameof(plcSoftware), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(plcSoftware.TypeGroup, ref collection);

            return collection;
        }

        /// <summary>
        /// Returns a TreeView of all ExternalSourceFiles in the PlcSoftware
        /// </summary>
        /// <param name="plcSoftware">PlcSoftware to be searched</param>
        /// <returns>TreeView of ExternalSourceFiles</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;PlcSoftware</exception>
        public static TreeNode GetExternalSourceFilesTreeView(PlcSoftware plcSoftware)
        {
            if (plcSoftware == null)
                throw new ArgumentNullException(nameof(plcSoftware), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(plcSoftware.ExternalSourceGroup, ref collection);

            return collection;
        }

        /// <summary>
        /// Returns a TreeNode of all hardware objects in the ContollesTarget
        /// </summary>
        /// <param name="plcSoftware">PlcSoftware to be searched</param>
        /// <returns>TreeNode of hardware objects</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;PlcSoftware</exception>
        public static TreeNode GetHardwareTreeView(PlcSoftware plcSoftware)
        {
            if (plcSoftware == null)
                throw new ArgumentNullException(nameof(plcSoftware), "Parameter is null");

            var station = plcSoftware.Parent as Device;
            if (station == null) throw new ArgumentNullException(nameof(station));

            var item = new TreeNode();
            item.Name = station.Name;
            item.Tag = station;
            foreach (var subItem in station.DeviceItems)
            {
                item.Nodes.Add(RecursiveGetDevicesTreeView(subItem));
            }
            return item;
        }

        /// <summary>Returns TreeNode of all screens in hmiTarget</summary>
        /// <param name="hmiTarget">The hmi target.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;hmiTarget</exception>
        public static TreeNode GetScreensTreeView(HmiTarget hmiTarget)
        {
            if (hmiTarget == null)
                throw new ArgumentNullException(nameof(hmiTarget), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(hmiTarget.ScreenFolder, ref collection);

            return collection;
        }

        /// <summary>Returns TreeNode of all TagTables in hmiTarget</summary>
        /// <param name="hmiTarget">The hmi target.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;hmiTarget</exception>
        public static TreeNode GetTagTablesTreeView(HmiTarget hmiTarget)
        {
            if (hmiTarget == null)
                throw new ArgumentNullException(nameof(hmiTarget), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(hmiTarget.TagFolder, ref collection);

            return collection;
        }


        /// <summary>Returns TreeNode of all user Cycles in hmiTarget</summary>
        /// <param name="hmiTarget">The hmi target.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;hmiTarget</exception>
        public static TreeNode GetCyclesTreeView(HmiTarget hmiTarget)
        {
            if (hmiTarget == null)
                throw new ArgumentNullException(nameof(hmiTarget), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(hmiTarget.Cycles, ref collection);

            return collection;
        }

        /// <summary>Returns TreeNode of all Connections in hmiTarget</summary>
        /// <param name="hmiTarget">The hmi target.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;hmiTarget</exception>
        public static TreeNode GetConnectionsTreeView(HmiTarget hmiTarget)
        {
            if (hmiTarget == null)
                throw new ArgumentNullException(nameof(hmiTarget), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(hmiTarget.Connections, ref collection);

            return collection;
        }

        /// <summary>Returns TreeNode of all VB Scripts in hmiTarget</summary>
        /// <param name="hmiTarget">The hmi target.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;hmiTarget</exception>
        public static TreeNode GetScriptsTreeView(HmiTarget hmiTarget)
        {
            if (hmiTarget == null)
                throw new ArgumentNullException(nameof(hmiTarget), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(hmiTarget.VBScriptFolder, ref collection);

            return collection;
        }

        /// <summary>Returns TreeNode of all ScreenTemplates in hmiTarget</summary>
        /// <param name="hmiTarget">The hmi target.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;hmiTarget</exception>
        public static TreeNode GetScreenTemplatesTreeView(HmiTarget hmiTarget)
        {
            if (hmiTarget == null)
                throw new ArgumentNullException(nameof(hmiTarget), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(hmiTarget.ScreenTemplateFolder, ref collection);

            return collection;
        }

        /// <summary>Returns TreeNode of all ScreenPopups in hmiTarget</summary>
        /// <param name="hmiTarget">The hmi target.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;hmiTarget</exception>
        public static TreeNode GetScreenPopupTreeView(HmiTarget hmiTarget)
        {
            if (hmiTarget == null)
                throw new ArgumentNullException(nameof(hmiTarget), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(hmiTarget.ScreenPopupFolder, ref collection);

            return collection;
        }

        /// <summary>Returns TreeNode of all ScreenSlideIns in hmiTarget</summary>
        /// <param name="hmiTarget">The hmi target.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;hmiTarget</exception>
        public static TreeNode GetScreenSlideInTreeView(HmiTarget hmiTarget)
        {
            if (hmiTarget == null)
                throw new ArgumentNullException(nameof(hmiTarget), "Parameter is null");

            var collection = new TreeNode();

            RecursiveGetTreeView(hmiTarget.ScreenSlideinFolder, ref collection);

            return collection;
        }

        /// <summary>
        /// Returns a TreeNode of all hardware objects in the HmiTarget
        /// </summary>
        /// <param name="hmiTarget">HmiTarget to be searched</param>
        /// <returns>TreeNode of hardware objects</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;hmiTarget</exception>
        public static TreeNode GetHardwareTreeView(HmiTarget hmiTarget)
        {
            if (hmiTarget == null)
                throw new ArgumentNullException(nameof(hmiTarget), "Parameter is null");

            var station = hmiTarget.Parent as Device;
            if (station == null) throw new ArgumentNullException(nameof(station));

            var item = new TreeNode();
            item.Name = station.Name;
            item.Tag = station;
            foreach (var subItem in station.DeviceItems)
            {
                item.Nodes.Add(RecursiveGetDevicesTreeView(subItem));
            }
            return item;
        }

        /// <summary>Returns all ILibraryTypes in folder as TreeViewItems</summary>
        /// <param name="folder">The folder.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;folder</exception>
        public static TreeNode GetTypesTreeView(LibraryTypeFolder folder)
        {
            if (folder == null)
                throw new ArgumentNullException(nameof(folder), "Parameter is null");

            var treeViewItem = new TreeNode();
            treeViewItem.Name = folder.Name;
            treeViewItem.Tag = folder;

            foreach (var type in folder.Types)
            {
                var sub = new TreeNode();
                sub.Name = type.Name;
                sub.Tag = type;

                treeViewItem.Nodes.Add(sub);
            }

            foreach (var subfolder in folder.Folders)
            {
                var subView = GetTypesTreeView(subfolder);

                treeViewItem.Nodes.Add(subView);
            }

            return treeViewItem;
        }

        /// <summary>Returns all MasterCopies in folder as TreeViewItems</summary>
        /// <param name="folder">The folder.</param>
        /// <returns>TreeNode</returns>
        /// <exception cref="System.ArgumentNullException">Parameter is null;folder</exception>
        public static TreeNode GetMasterCopiesTreeView(MasterCopyFolder folder)
        {
            if (folder == null)
                throw new ArgumentNullException(nameof(folder), "Parameter is null");

            var treeViewItem = new TreeNode();

            treeViewItem.Name = OpennessHelper.GetObjectName(folder);
            treeViewItem.Tag = folder;

            foreach (var mCopy in folder.MasterCopies)
            {
                var sub = new TreeNode();
                sub.Name = mCopy.Name;
                sub.Tag = mCopy;

                treeViewItem.Nodes.Add(sub);
            }

            foreach (var subfolder in folder.Folders)
            {
                var subView = GetMasterCopiesTreeView(subfolder);

                treeViewItem.Nodes.Add(subView);
            }

            return treeViewItem;
        }

        /// <summary>Returns a TreeNode representing the library</summary>
        /// <param name="library">The library.</param>
        /// <returns>TreeNode</returns>
        public static TreeNode GetLibraryTreeView(ILibrary library)
        {
            var treeViewItem = new TreeNode();
            if (library is GlobalLibrary)
            {
                var splitPath = (library as GlobalLibrary).Path.FullName.Split('\\', '.');
                treeViewItem.Name = splitPath[splitPath.Length - 2];
            }
            else
            {
                treeViewItem.Name = "Project Library";
            }
            treeViewItem.Tag = library;

            treeViewItem.Nodes.Add(GetTypesTreeView(library.TypeFolder));
            treeViewItem.Nodes.Add(GetMasterCopiesTreeView(library.MasterCopyFolder));

            return treeViewItem;
        }
    }
}
