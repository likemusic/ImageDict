using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ImageDict.Controls
{
    class SelectablePanel : Panel
    {
        public event MouseEventHandler MouseWheel;

        public SelectablePanel()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down) return true;
            if (keyData == Keys.Left || keyData == Keys.Right) return true;
            return base.IsInputKey(keyData);
        }

        /*protected override void OnEnter(EventArgs e)
        {
            this.Invalidate();
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            this.Invalidate();
            base.OnLeave(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (this.Focused)
            {
                var rc = this.ClientRectangle;
                rc.Inflate(-1, -1);
                ControlPaint.DrawFocusRectangle(pe.Graphics, rc);
            }
        }*/

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (MouseWheel != null)
                    MouseWheel(this, e);
                //((HandledMouseEventArgs)e).Handled = true;
                //base.OnMouseWheel(e);
                //((HandledMouseEventArgs)e).Handled = true;
                //MouseEventHandler handler = MouseWheel;
                //this.MouseWheel(this, e);
            }
            else base.OnMouseWheel(e);
        }
    }
}
