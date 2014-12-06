using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageDict.Logic
{
    public class NotifyHelper
    {
        public void ShowError(string ErrorMessage)
        {
            string ErrorMessageBoxCaption = "Ошибка";
            MessageBox.Show(ErrorMessage, ErrorMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfo(string InfoMessage, string Caption)
        {
            MessageBox.Show(InfoMessage, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
