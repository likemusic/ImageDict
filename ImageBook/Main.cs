using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageBook.Entity;
using ImageBook.Logic;
using System.IO;

namespace ImageBook
{
    public partial class Main : Form
    {
        //protected Env Env;
        //protected EnvData EnvData;
        protected Dictionary<string,int> CurrentContentsList;
        protected ContentsListHelper ContentHelper = new ContentsListHelper();

        public Main()
        {
            InitializeComponent();
            var DefaultSettings = Properties.Settings.Default;
            string DefaultContentFilename = Path.Combine(DefaultSettings.DefaultDataDirectory,DefaultSettings.DefaultContentsListFilename);

            var ContentsListHelper = new ContentsListHelper();
            CurrentContentsList = ContentsListHelper.LoadFromTxtFile(DefaultContentFilename);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            var TextBox = sender as TextBox;
            string ImageFilename = ContentHelper.GetFilenameBySearchString(TextBox.Text, CurrentContentsList);
            ShowImage(ImageFilename);
        }

        protected void ShowImage(string Filename)
        {
            MessageBox.Show(Filename);
        }
    }
}
