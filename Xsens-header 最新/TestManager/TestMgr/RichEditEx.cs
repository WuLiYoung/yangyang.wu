using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestMgr
{
    class TransparentControl : Control
    {
        public TransparentControl()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }

    class TransparentRichTextBox : RichTextBox
    {
        public TransparentRichTextBox()
        {
            base.ScrollBars = RichTextBoxScrollBars.None;
        }

        override protected CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        override protected void OnPaintBackground(PaintEventArgs e)
        {
        }
    }
}
