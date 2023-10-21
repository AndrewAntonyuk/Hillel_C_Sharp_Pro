using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFilesWPF.Presenter
{
    public interface IMainWindowPresenter
    {
        void CopyButtonClick();

        void ChooseFileFromButtonClick();

        void ChooseFileToButtonClick();
    }
}
