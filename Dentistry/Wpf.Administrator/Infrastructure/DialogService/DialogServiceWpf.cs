using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf.Administrator.Infrastructure.DialogService
{

    public class DialogServiceWpf : IDialogService
    {
        public DialogServiceWpf()
        {

        }
        public string FilePath { get; set; }
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }
        public DialogResult MessageBoxYesNo(string msg, string caption = "")
        {
            var result = MessageBox.Show(msg, caption, MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                return DialogResult.Yes;
            }
            return DialogResult.No;
        }
        public void MessageBoxOkError(string msg, string caption = "")
        {
            MessageBox.Show(msg, caption, MessageBoxButton.OK,MessageBoxImage.Error);
        }


    }
}
