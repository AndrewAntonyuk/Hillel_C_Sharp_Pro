using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CopyFilesWPF.Model
{
    public class FileCopier
    {
        private readonly Grid _gridPanel;
        private readonly FilePath _filePath;

        public delegate void ProgressChangeDelegate(double progress, ref bool cancle, Grid gritPanel);
        public delegate void CompleteDelegate(Grid gritPanel);

        public event ProgressChangeDelegate OnProgressChanged;
        public event CompleteDelegate OnComplete;

        public bool CancelFlag = false;
        public ManualResetEvent PauseFlag = new(true);

        public FileCopier(FilePath filePath,  ProgressChangeDelegate onProgressChange, CompleteDelegate onComplete, Grid gridPanel)
        {
            _gridPanel = gridPanel;
            _filePath = filePath;
            OnProgressChanged += onProgressChange;
            OnComplete += onComplete;
        }

        public void CopyFile()
        {
            byte[] buffer = new byte[1024 * 1024];
            bool isCopy = true;

            while(isCopy)
            {
                try
                {
                    using(var source = new FileStream(_filePath.PathFrom, FileMode.Open, FileAccess.Read))
                    {
                        var fileLenght = source.Length;
                        using var destination = new FileStream(_filePath.PathTo, FileMode.CreateNew, FileAccess.Write);

                        long total = 0;
                        int currentBlockSize = 0;

                        while((currentBlockSize = source.Read(buffer, 0 , buffer.Length)) > 0)
                        {
                            total += currentBlockSize;
                            double percentage = total * 100 / fileLenght;
                            destination.Write(buffer, 0, currentBlockSize);

                            OnProgressChanged(percentage, ref CancelFlag, _gridPanel);

                            if(CancelFlag)
                            {
                                File.Delete(_filePath.PathTo);
                                isCopy = false;
                                break;
                            }

                            CancelFlag = false;
                            PauseFlag.WaitOne(Timeout.Infinite);
                        }
                    }
                }
                catch(IOException e)
                {
                    if(! CancelFlag)
                    {
                        var result = MessageBox.Show(e.Message + " Replace?", "Replace?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        isCopy = result == MessageBoxResult.Yes;

                        if(isCopy)
                        {
                            File.Delete(_filePath.PathTo);
                        }
                    }
                    else
                    {
                        MessageBox.Show(e.Message + " Copying was canceled", "Cancel", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        isCopy = false;
                        File.Delete(_filePath.PathTo);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error occurred!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            OnComplete(_gridPanel);
        }
    }
}
