using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Signature.Windows.Forms
{
    public class MouseBounds : IMessageFilter
    {
        private const int WM_NCMOUSEMOVE = 0x00A0;
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_NCMOUSELEAVE = 0x02A2;
        private const int WM_MOUSELEAVE = 0x02A3;

        private bool _mouseInBounds = false;

        public event EventHandler MouseBoundsChanged;

        private FadingForm faderForm;

        public MouseBounds(FadingForm faderForm)
        {
            this.faderForm = faderForm;
        }

        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_MOUSEMOVE:
                case WM_NCMOUSEMOVE:
                    CheckMouseBounds(true);
                    break;

                case WM_NCMOUSELEAVE:
                case WM_MOUSELEAVE:
                    CheckMouseBounds(false);
                    break;
            }

            return false; // dont actually filter the message
        }

        /// <summary>
        /// Checks if the current cursor position is contained within the bounds of the
        /// form and sets MouseInBounds which in turn fires event MouseBoundsChanged
        /// </summary>
        /// <param name="mouseMove"></param>
        private void CheckMouseBounds(bool mouseMove)
        {
            // Already know the mouse is in the bounds, so we dont
            // care that the mouse just moved (saves unnecessary checks
            // on the form bounds and OnMouseBoundsChanged calls)
            if ((MouseInBounds) && (mouseMove))
                return;

            // if the cursor is in the bounds of the current form 
            // set the bounds to true, else set the bounds to false
            SetMouseBounds(faderForm.Bounds.Contains(Cursor.Position));
        }

        public void SetMouseBounds(bool mouseInBounds)
        {
            // prevent setting the bounds status to the same as it was
            // already set (shouldn't happen anyway, so this is just a
            // sanity check)
            if (mouseInBounds != _mouseInBounds)
            {
                _mouseInBounds = mouseInBounds;
                OnMouseBoundsChanged(EventArgs.Empty);
            }
        }

        private void OnMouseBoundsChanged(EventArgs e)
        {
            if (MouseBoundsChanged != null)
                MouseBoundsChanged(this, e);
        }

        public bool MouseInBounds
        {
            get
            {
                return _mouseInBounds;
            }
        }
    }
}
