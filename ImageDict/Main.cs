using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageDict.Entity;
using ImageDict.Logic;
using System.IO;

namespace ImageDict
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
            EnvData.DictData = DictHelper.OpenFromDir(ImageDict.Properties.Settings.Default.DefaultSourceDir);
            //pnlContent.KeyPress += new KeyPressEventHandler(pnlContent_KeyPress);
            pnlContent.KeyDown += new KeyEventHandler(pnlContent_KeyDown);
            pnlContent.MouseWheel += new MouseEventHandler(pnlContent_MouseWheel);


            HandOpenCursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.HandOpen));
            HandMoveCursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.HandMove));
            pbContent.Cursor = HandOpenCursor;

            EnvData.CurrentPage = EnvData.DictData.Settings.MinPage;
            ShowImageByPageNum(EnvData.CurrentPage);
        }

        #region Controls Handlers
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            var TextBox = sender as TextBox;
            int PageNumber, ImageNumber, ImagePart;
            string ImageFilename = DictHelper.GetFilenameBySearchString(TextBox.Text, EnvData.DictData, out PageNumber, out ImageNumber, out ImagePart);
            EnvData.CurrentPage = PageNumber;
            ShowImageByFilenameAndPartNum(ImageFilename, ImagePart, EnvData.DictData.Settings.WordsPerFile);
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

        protected void pnlContent_MouseWheel(object sender, MouseEventArgs e)
        {
            Control Control = (Control) sender;
            double NewScale;
            if (Control.ModifierKeys == Keys.Control)
            {
                if(e.Delta < 0 ) NewScale = EnvData.Scale / Math.Pow(EnvData.ScaleStep, Math.Abs(e.Delta/120));
                else NewScale = EnvData.Scale * Math.Pow(EnvData.ScaleStep, Math.Abs(e.Delta/120));
                SetNewScale(NewScale);
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }
        #endregion

        #region Helper Funcs
        protected void ShowImageByFilenameAndPartNum(string Filename, int PartNum, int TotalParts)
        {
            try
            {
                Image Image = GetImageByFilenameAndPartNum(Filename, PartNum, TotalParts);
                EnvData.Image = Image;
                pbContent.Image = GetScaledImage(EnvData.Scale, Image);
                //button1.Image = Image;
                CenterPictureBox();
            }
            catch (Exception Ex)
            {
                NotifyHelper.ShowError("Can't load image:" + Ex.Message);
            }
        }

        protected Image GetScaledImage(double Scale, Image Image)
        {
           Bitmap src = Image as Bitmap;
            int newWidth = (int) (src.Width * Scale);
            int newHeight = (int) (src.Height * Scale);

            Bitmap target = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height));//, cropRect, GraphicsUnit.Pixel
            }
            return target;
        }

        protected Image GetImageByFilenameAndPartNum(string Filename, int PartNum, int TotalParts)
        {
            Bitmap src = Image.FromFile(Filename) as Bitmap;
            if (TotalParts == 1) return src;

            int PartSize = src.Width / TotalParts;
            Rectangle cropRect = new Rectangle(PartNum * PartSize, 0, PartSize, src.Height);

            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
            using (var g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),cropRect,GraphicsUnit.Pixel);
            }
            return target;
        }

        protected void ShowImageByPageNum(int PageNum)
        {
            int ImageNumber, ImagePart;
            string Filename = DictHelper.GetFilenameByPageNumber(PageNum, EnvData.DictData, out ImageNumber, out ImagePart);
            ShowImageByFilenameAndPartNum(Filename, ImagePart, EnvData.DictData.Settings.PagesPerFile);
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
            int MinPage = EnvData.DictData.Settings.MinPage;

            if(CurrentPage == EnvData.DictData.Settings.MaxPage) btNext.Enabled = true;

            CurrentPage--;
            if (CurrentPage < MinPage) CurrentPage = MinPage;
            if (CurrentPage == MinPage) btPrev.Enabled = false;
            EnvData.CurrentPage = CurrentPage;
            ShowImageByPageNum(CurrentPage);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            int CurrentPage = EnvData.CurrentPage;
            int MaxPage = EnvData.DictData.Settings.MaxPage;

            if (CurrentPage == EnvData.DictData.Settings.MinPage) btPrev.Enabled = true;

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
                case Keys.Home:
                    ScrollToTop();
                    break;
                case Keys.End:
                    ScrollToBottom();
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

        protected void ScrollToTop()
        {
            pnlContent.VerticalScroll.Value = pnlContent.VerticalScroll.Minimum;
            pnlContent.PerformLayout();
        }

        protected void ScrollToBottom()
        {
            pnlContent.VerticalScroll.Value = pnlContent.VerticalScroll.Maximum;
            pnlContent.PerformLayout();
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string ScaleText = cbScale.Text.Trim().Replace("%",String.Empty);
            double ScaleInPercents;
            if (!Double.TryParse(ScaleText, out ScaleInPercents)) return;
            double Scale = ScaleInPercents / 100;
            ChangeScale(Scale);
        }

        protected void ChangeScale(double Scale)
        {
            EnvData.Scale = Scale;
            ImageDict.Controls.Win32Helper.SuspendPainting(pbContent.Handle);
            pbContent.Image = GetScaledImage(Scale, EnvData.Image);
            CenterPictureBox();
            ImageDict.Controls.Win32Helper.ResumePainting(pbContent.Handle);
            pnlContent.Refresh();
        }

        protected void SetNewScale(double Scale)
        {
            double NewScale = Scale * 100;
            NewScale = Math.Round(NewScale, 2);
            cbScale.Text = NewScale.ToString() + "%";
        }

        private void btnScaleMinus_Click(object sender, EventArgs e)
        {
            SetNewScale(EnvData.Scale / EnvData.ScaleStep);
        }

        private void btnScalePlus_Click(object sender, EventArgs e)
        {
            SetNewScale(EnvData.Scale * EnvData.ScaleStep);
        }
    }
}
