using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Signature.Classes;

namespace Signature.Windows.Forms
{
    public partial class GradientForm : FadingForm 
    {
        private Color _color1 = Color.White;
        private Color _color2 = Color.FromArgb(85, 105, 141);
        private LinearGradientMode _linearGradientMode = LinearGradientMode.ForwardDiagonal;

        public GradientForm()
        {
            InitializeComponent();

            // reduce flicker
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.OptimizedDoubleBuffer | 
                          ControlStyles.ResizeRedraw | 
                          ControlStyles.UserPaint, true);
        }

        public Color GradientStartColor
        {
            get
            {
                return _color1;
            }

            set
            {
                _color1 = value;
            }
        }

        public Color GradientEndColor
        {
            get
            {
                return _color2;
            }

            set
            {
                _color2 = value;
            }
        }

        public LinearGradientMode LinearGradientMode
        {
            get
            {
                return _linearGradientMode;
            }

            set
            {
                _linearGradientMode = value;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            DrawGradient(e.Graphics, _color1, _color2, _linearGradientMode, ClientRectangle);
            //base.OnPaintBackground(e);
        }

        private void DrawGradient(Graphics g, System.Drawing.Color Color1, System.Drawing.Color Color2, LinearGradientMode Direction, Rectangle Rect)
        {
            if ((Rect.Width != 0) & (Rect.Height != 0))
            {
                LinearGradientBrush lBrush = new LinearGradientBrush(Rect, Color1, Color2, Direction);
                g.FillRectangle(lBrush, Rect);
            }
        }
    }
}