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

        protected bool IsMoveContent;
        int clickOffsetX;
        int clickOffsetY;

        int scrollOffsetX;
        int scrollOffsetY;

        protected int LastScrollYDelta;

        protected Cursor HandOpenCursor, HandMoveCursor;

        public Main()
        {
            InitializeComponent();
            EnvData.DictData = DictHelper.OpenFromDir(ImageBook.Properties.Settings.Default.DefaultSourceDir);
            //pnlContent.KeyPress += new KeyPressEventHandler(pnlContent_KeyPress);
            pnlContent.KeyDown += new KeyEventHandler(pnlContent_KeyDown);

            HandOpenCursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.HandOpen));
            HandMoveCursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.HandMove));
            pbContent.Cursor = HandOpenCursor;
        }

        #region Controls Handlers
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            var TextBox = sender as TextBox;
            int PageNumber;
            string ImageFilename = DictHelper.GetFilenameBySearchString(TextBox.Text, EnvData.DictData, out PageNumber);
            EnvData.CurrentPage = PageNumber;
            ShowImageByFilename(ImageFilename);
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
        protected void ShowImageByFilename(string Filename)
        {
            try
            {
                pbContent.Image = Image.FromFile(Filename);
                //button1.Image = Image.FromFile(Filename);
                CenterPictureBox();
            }
            catch (Exception Ex)
            {
                NotifyHelper.ShowError("Can't load image:" + Ex.Message);
            }
        }

        protected void ShowImageByPageNum(int PageNum)
        {
            string Filename = DictHelper.GetFilenameByPageNumber(PageNum, EnvData.DictData);
            ShowImageByFilename(Filename);
        }

        protected void CenterPictureBox()
        {
            var ParentSize = pbContent.Parent.Size;
            var AutoScrollPosition = pnlContent.AutoScrollPosition;
            int X=AutoScrollPosition.X, Y=AutoScrollPosition.Y;
            if (ParentSize.Width > pbContent.Width)
                X = ((ParentSize.Width - pbContent.Width) / 2) + AutoScrollPosition.X;

            if (ParentSize.Height > pbContent.Height)
                Y = ((ParentSize.Height - pbContent.Height) / 2) + AutoScrollPosition.Y;
            pbContent.Location = new Point(X, Y);
        }
        #endregion

        private void btPrev_Click(object sender, EventArgs e)
        {
            int CurrentPage = EnvData.CurrentPage;
            int MinPage = EnvData.DictData.MinPage;

            if(CurrentPage == EnvData.DictData.MaxPage) btNext.Enabled = true;

            CurrentPage--;
            if (CurrentPage < MinPage) CurrentPage = MinPage;
            if (CurrentPage == MinPage) btPrev.Enabled = false;
            EnvData.CurrentPage = CurrentPage;
            ShowImageByPageNum(CurrentPage);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            int CurrentPage = EnvData.CurrentPage;
            int MaxPage = EnvData.DictData.MaxPage;

            if (CurrentPage == EnvData.DictData.MinPage) btPrev.Enabled = true;

            CurrentPage++;
            if (CurrentPage > MaxPage) CurrentPage = MaxPage;
            if (CurrentPage == MaxPage) btNext.Enabled = false;
            EnvData.CurrentPage = CurrentPage;
            ShowImageByPageNum(CurrentPage);
        }

        private void pnlContent_Click(object sender, EventArgs e)
        {
            var Panel = (Panel)sender;
            Panel.Focus();
        }

        private void pnlContent_KeyDown(Object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageDown:
                case Keys.Space:
                    ScrollPageDown();
                    break;
                case Keys.PageUp:
                    ScrollPageUp();
                    break;
                case Keys.Up:
                    ScrollUp();
                    break;
                case Keys.Down:
                    ScrollDown();
                    break;
                case Keys.Right:
                    ScrollRight();
                    break;
                case Keys.Left:
                    ScrollLeft();
                    break;
            }
        }

        protected void ScrollAny(Panel Panel, ScrollProperties Scroll, bool IsAdd=true, bool IsLarge=true)
        {
            int Limit = (IsAdd) ? Scroll.Maximum : Scroll.Minimum;
            int Delta = (IsLarge) ? Scroll.LargeChange : Scroll.SmallChange;
            if(!IsAdd) Delta = -Delta;

            int NewValue = Scroll.Value + Delta;

            if( (IsAdd && (NewValue>Limit)) || (!IsAdd && (NewValue<Limit)) ) NewValue = Limit;
            Scroll.Value = NewValue;
            Panel.PerformLayout();
        }

        protected void ScrollPageDown()
        {
            bool IsAdd = true;
            bool IsLarge = true;
            ScrollAny(pnlContent, pnlContent.VerticalScroll, IsAdd, IsLarge);
        }

        protected void ScrollPageUp()
        {
            bool IsAdd = false;
            bool IsLarge = true;
            ScrollAny(pnlContent, pnlContent.VerticalScroll, IsAdd, IsLarge);
        }

        protected void ScrollDown()
        {
            bool IsAdd = true;
            bool IsLarge = false;
            ScrollAny(pnlContent, pnlContent.VerticalScroll, IsAdd, IsLarge);
        }

        protected void ScrollUp()
        {
            bool IsAdd = false;
            bool IsLarge = false;
            ScrollAny(pnlContent, pnlContent.VerticalScroll, IsAdd, IsLarge);
        }

        protected void ScrollLeft()
        {
            bool IsAdd = false;
            bool IsLarge = false;
            ScrollAny(pnlContent, pnlContent.HorizontalScroll, IsAdd, IsLarge);
        }

        protected void ScrollRight()
        {
            bool IsAdd = true;
            bool IsLarge = false;
            ScrollAny(pnlContent, pnlContent.HorizontalScroll, IsAdd, IsLarge);
        }

        private void pbContent_Click(object sender, EventArgs e)
        {
            var ImageBox = (PictureBox)sender;
            ImageBox.Parent.Focus();
        }

        private void pbContent_MouseDown(object sender, MouseEventArgs e)
        {
            IsMoveContent = true;
            Cursor.Current = HandMoveCursor;
            var MousePosition = Control.MousePosition;
            clickOffsetX = MousePosition.X;
            clickOffsetY = MousePosition.Y;

            scrollOffsetX = pnlContent.HorizontalScroll.Value;
            scrollOffsetY = pnlContent.VerticalScroll.Value;
            //pnlContent.SuspendLayout();
        }

        private void pbContent_MouseUp(object sender, MouseEventArgs e)
        {
            IsMoveContent = false;
            Cursor.Current = HandOpenCursor;
        }

        private void pbContent_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (IsMoveContent == true)
            {
                var ParentPanel = (Panel) c.Parent;
                var MousePosition = Control.MousePosition;

                int newOffsetX = MousePosition.X;
                int newkOffsetY = MousePosition.Y;

                int deltaX = newOffsetX - clickOffsetX;
                int deltaY = newkOffsetY - clickOffsetY;

                int NewX = scrollOffsetX - deltaX;
                int NewY = scrollOffsetY - deltaY;
                LastScrollYDelta = deltaY;
                if (NewX < ParentPanel.HorizontalScroll.Minimum) NewX = ParentPanel.HorizontalScroll.Minimum;
                if (NewX > ParentPanel.HorizontalScroll.Maximum) NewX = ParentPanel.HorizontalScroll.Maximum;

                if (NewY < ParentPanel.VerticalScroll.Minimum) NewY = ParentPanel.VerticalScroll.Minimum;
                if (NewY > ParentPanel.VerticalScroll.Maximum) NewY = ParentPanel.VerticalScroll.Maximum;

                if (NewY != ParentPanel.VerticalScroll.Value) ParentPanel.VerticalScroll.Value = NewY;
                if (NewX != ParentPanel.HorizontalScroll.Value) ParentPanel.HorizontalScroll.Value = NewX;
                //pnlContent.PerformLayout();
            }
        }
    }
}
