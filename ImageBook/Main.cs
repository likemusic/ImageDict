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
        protected NotifyHelper NotifyHelper = new NotifyHelper();

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
            //MessageBox.Show(Filename);
            string FullFilename = Path.Combine(Properties.Settings.Default.DefaultDataDirectory,Filename);
            try
            {
                pbContetn.Image = Image.FromFile(FullFilename);
                CenterPictureBox();
            }
            catch (Exception Ex)
            {
                NotifyHelper.ShowError("Can't load image:" + Ex.Message);
            }
        }

        protected void CenterPictureBox()
        {
            var ParentSize = pbContetn.Parent.Size;
            var AutoScrollPosition = pnlContent.AutoScrollPosition;
            int X=AutoScrollPosition.X, Y=AutoScrollPosition.Y;
            if (ParentSize.Width > pbContetn.Width)
                X = ((ParentSize.Width - pbContetn.Width) / 2) + AutoScrollPosition.X;

            if (ParentSize.Height > pbContetn.Height)
                Y = ((ParentSize.Height - pbContetn.Height) / 2) + AutoScrollPosition.Y;
            pbContetn.Location = new Point(X, Y);
            //pbContetn.Refresh();
        }

        private void btLitAE_Click(object sender, EventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Insert(tbSearch.SelectionStart,"Æ");
        }

        private void btLitO_Click(object sender, EventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Insert(tbSearch.SelectionStart, "Ø");
        }

        private void btLitA_Click(object sender, EventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Insert(tbSearch.SelectionStart, "Å");
        }

        private void pnlContent_Resize(object sender, EventArgs e)
        {
            CenterPictureBox();
        }
    }
}
