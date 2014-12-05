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
        protected DictHelper DictHelper = new DictHelper();
        protected DictData DictData;

        protected Env Env = new Env();
        protected EnvData EnvData = new EnvData();
        
        protected NotifyHelper NotifyHelper = new NotifyHelper();

        public Main()
        {
            InitializeComponent();
            EnvData.DictData = DictHelper.OpenFromDir(ImageBook.Properties.Settings.Default.DefaultSourceDir);
        }

        #region Controls Handlers
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            var TextBox = sender as TextBox;
            string ImageFilename = DictHelper.GetFilenameBySearchString(TextBox.Text, EnvData.DictData);
            ShowImage(ImageFilename);
        }

        private void btLitAE_Click(object sender, EventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Insert(tbSearch.SelectionStart, "Æ");
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
        #endregion

        #region Helper Funcs
        protected void ShowImage(string Filename)
        {
            try
            {
                pbContetn.Image = Image.FromFile(Filename);
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
        #endregion
    }
}
