using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Administrator.Infrastructure.DialogService
{
    public interface IDialogService
    {
        string FilePath { get; set; }
        bool OpenFileDialog();// открытие файла
        bool SaveFileDialog();  // сохранение файла
        DialogResult MessageBoxYesNo(string msg, string caption = "");
        void MessageBoxOkError(string msg, string caption = "");

    }
}
