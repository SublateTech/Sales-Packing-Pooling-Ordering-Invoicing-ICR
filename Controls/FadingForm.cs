using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Signature.Windows.Forms
{
    public partial class FadingForm : Form
    {
        #region Private Fader Varaibles

        public enum Fades
        {
            FadeIn,
            FadeOut,
            NotFading
        }

        // flag to indicate if the form has already been shown (hidden)
        private bool firstShow = true;

        private Fades _currentFade; // what direction is the fade approching in 
        // relation to the current opacity level of the from

        // sets a value to determin if the form should fade to full opacity on mouse enter
        private bool _fullOpacityOnHover = true;

        // rate for fade in of form
        private int _fadeRate = 1;

        // saved setting for fade on close
        private bool _fadeOnShow = true;
        private bool _fadeOnClose = true;

        // value to control opacity increments
        private double _fadeAmount = .025;

        // value indicating the level of opacity beeing faded towards
        private double _fadeOpacity = 1;
        private double _showOpacity = 1;
        private double _currentFadeOpacity = 1; // used internally

        // timer for fade of form
        private Timer fadeTimer = new Timer();

        #endregion

        public event EventHandler OpacityChanged;
        public event EventHandler FadeOpacityChanged;
        public event EventHandler CurrentFadeChanged;

        private MouseBounds mouseBounds;

        public FadingForm()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            #region MouseBounds Handler

            mouseBounds = new MouseBounds(this);
            mouseBounds.MouseBoundsChanged += new EventHandler(mouseBounds_MouseBoundsChanged);

            #endregion

            #region fadeTimer event Handler

            fadeTimer.Tick += new EventHandler(FadeTimer_Tick);

            #endregion

            // forces WinForms to convert the window to a layered window, reducing
            // some flicker noticed when first displaying the form
            TransparencyKey = Color.LimeGreen;
        }

        #region On Property Change

        private void OnOpacityChanged(EventArgs e)
        {
            if (OpacityChanged != null)
                OpacityChanged(this, e);
        }

        private void OnFadeOpaictyChanged(EventArgs e)
        {
            if (FadeOpacityChanged != null)
                FadeOpacityChanged(this, e);
        }

        private void OnCurrentFadeChanged(EventArgs e)
        {
            if (CurrentFadeChanged != null)
                CurrentFadeChanged(this, e);
        }

        #endregion

        #region Form Overrides

        public new double Opacity
        {
            get
            {
                return base.Opacity;
            }

            set
            {
                base.Opacity = value;
                OnOpacityChanged(EventArgs.Empty);
            }
        }

        public new void Show()
        {
            base.Show();

            // if the form was hidden and is being re-shown it is necessary to
            // call OnShown. WinForms does not do this unless it is the first show
            if ((!firstShow) && (!DesignMode))
            {
                if (FadeOnShow == true)
                {
                    Opacity = 0;
                    ShowFade();
                }
                else
                    Opacity = _showOpacity;
            }
                
                
        }

        public new void ShowDialog()
        {
            base.ShowDialog();

            // if the form was hidden and is being re-shown it is necessary to
            // call OnShown. WinForms does not do this unless it is the first show
            if ((!firstShow) && (!DesignMode))
            {
                if (FadeOnShow == true)
                {
                    Opacity = 0;
                    ShowFade();
                }
                else
                    Opacity = _showOpacity;
            }
        }

        public void ShowFade()
        {
            #region Fader

            if ((FadeOnShow == true) && (!DesignMode))
            {
                // set the target opacity (FadeOpacity) to be the value stored in FadeOnShowOpacity
                FadeOpacity = _showOpacity;
                FadeAndWait();
            }

            #endregion
        }

        protected override void OnShown(EventArgs e)
        {
            ShowFade();

            // set the falg to indicate the form has been shown at least once          
            firstShow = false;

            base.OnShown(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            // if the FadeOnShow property is true, start the form as hidden
            if (!DesignMode)
            {
                if (FadeOnShow == true)
                    Opacity = 0;
                else
                    Opacity = _showOpacity;
            }

            // adding the filter after the form has loaded prevents
            // the FullOpacityOnHover feature from causing problems with the
            // FadeOnLoad feature
            Application.AddMessageFilter(mouseBounds);

            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (e.Cancel == true)
                return;

            // remove the filter before preforming the close fade
            // to prevent the FullOpacityOnHover effect from causing a problem
            Application.RemoveMessageFilter(mouseBounds);

            #region Fader

            if ((_fadeOnClose == true) && (this.Visible == true) && (!DesignMode))
            {
                FullOpacityOnHover = false; //prevents the mouse hover from interupting any close fade
                FadeOpacity = 0;
                FadeAndWait();
            }

            #endregion
        }

        #endregion

        #region Properties

        [Category("Fader")]
        [Description("Gets/Sets rate at which the fade is applied")]
        [DefaultValue(1)]
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public int FadeRate
        {
            get
            {
                return _fadeRate;
            }

            set
            {
                _fadeRate = value;
            }
        }

        [Browsable(true)]
        [Category("Fader")]
        [Description("Gets the current fade status")]
        public Fades CurrentFade
        {
            get
            {
                return _currentFade;
            }

        }

        private void SetCurrentFade(Fades currentFade)
        {
            _currentFade = currentFade;
            OnCurrentFadeChanged(EventArgs.Empty);
        }

        [Browsable(true)]
        [Category("Fader")]
        [Description("Gets/Sets a value incidating if the form is to fade upon loading")]
        [DefaultValue(true)]
        public bool FadeOnShow
        {
            get
            {
                return _fadeOnShow;
            }

            set
            {
                _fadeOnShow = value;
            }
        }

        [Browsable(true)]
        [Category("Fader")]
        [Description("Gets/Sets an opacity value in which the form should start with when displayed")]
        [DefaultValue(1)]
        public double ShowOpacity
        {
            get
            {
                return _showOpacity;
            }

            set
            {
                _showOpacity = value;
            }
        }

        [Browsable(true)]
        [Category("Fader")]
        [Description("Gets/Sets a value which allows the form to fade upon closing")]
        [DefaultValue(true)]
        public bool FadeOnClose
        {
            get
            {
                return _fadeOnClose;
            }

            set
            {
                _fadeOnClose = value;
            }
        }

        [Browsable(true)]
        [Category("Fader")]
        [Description("Gets/Sets a value which makes the form have full opacity when the mouse hovers")]
        [DefaultValue(true)]
        public bool FullOpacityOnHover
        {
            get
            {
                return _fullOpacityOnHover;
            }

            set
            {
                if ((_fullOpacityOnHover == true) && (value == false))
                {
                    //turning off Full Opacity On Hover
                    //force a fade to whatever FadeOpacity is set at
                    _currentFadeOpacity = FadeOpacity;
                    _fullOpacityOnHover = value;
                    Fade();
                }
                else
                {
                    _fullOpacityOnHover = value;

                    if (mouseBounds.MouseInBounds == true)
                    {
                        // turning on FullOpacityOnHover and mouse in form bounds
                        _currentFadeOpacity = 1;
                        Fade();
                    }
                }
            }
        }

        [Browsable(true)]
        [Category("Fader")]
        [Description("Gets/Sets the amount of opacity to incriment by")]
        [DefaultValue(.025)]
        public double FadeAmount
        {
            get
            {
                return _fadeAmount;
            }

            set
            {
                _fadeAmount = value;
            }
        }

        [Browsable(false)]
        [Description("Gets/Sets a value to fade to")]
        [DefaultValue(1)]
        public double FadeOpacity
        {
            get
            {
                return _fadeOpacity;
            }
            set
            {
                if ((FullOpacityOnHover) && (mouseBounds.MouseInBounds))
                {
                    _currentFadeOpacity = 1;
                }
                else
                {
                    _currentFadeOpacity = value;
                }

                _fadeOpacity = value;

                OnFadeOpaictyChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Fader

        /// <summary>
        /// Fades the form without chaning the starting opacity
        /// Starts at current opacity and goes to FadeOpacity
        /// Does not give up control until fading has stopped
        /// </summary>
        public void FadeAndWait()
        {
            Fade();
            do
            {
                Application.DoEvents();
            } while (_currentFade != Fades.NotFading);
        }


        /// <summary>
        /// Fades the form without chaning the starting opacity
        /// Starts at current opacity and goes to FadeOpacity
        /// </summary>
        public void Fade()
        {
            if (_fadeRate <= 0)
                return;

            if (fadeTimer.Enabled == true)
                fadeTimer.Stop(); //stop the current fade and allow this one to take priority

            //dont allow fading away from full if the mouse is 
            //in the form bounds and FullOpacityOnHover is true
            if ((FullOpacityOnHover) && (mouseBounds.MouseInBounds) && (Opacity == 1))
                return;

            //dont allow a fade if the destination equals the
            //the starting opacity
            if (Opacity == _currentFadeOpacity)
                return;

            //make sure we are fading in the direction that will 
            //get us to the FadeTo amount
            if (_currentFadeOpacity < this.Opacity)
            {
                _fadeAmount = -1 * Math.Abs(_fadeAmount);
                SetCurrentFade(Fades.FadeOut);
            }
            else
            {
                _fadeAmount = Math.Abs(_fadeAmount);
                SetCurrentFade(Fades.FadeIn);
            }

            fadeTimer.Interval = _fadeRate;
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            double newOpacity = this.Opacity + _fadeAmount;

            // checks the opacity is still within range
            if ((newOpacity >= 1) || (newOpacity <= 0))
                this.Opacity = _currentFadeOpacity;

            // check to see if the target has been reached
            switch (_currentFade)
            {
                case Fades.FadeIn:
                    if (newOpacity >= _currentFadeOpacity)
                        newOpacity = _currentFadeOpacity;

                    break;

                case Fades.FadeOut:
                    if (newOpacity <= _currentFadeOpacity)
                        newOpacity = _currentFadeOpacity;

                    break;
            }

            // set the opacity of the form to newOpacity
            this.Opacity = newOpacity;

            // stop the timer if the target has been reached
            if (newOpacity == _currentFadeOpacity)
            {
                SetCurrentFade(Fades.NotFading);
                fadeTimer.Stop();
            }
        }

        private void mouseBounds_MouseBoundsChanged(object sender, EventArgs e)
        {
            if (mouseBounds.MouseInBounds)
            {
                if ((_fullOpacityOnHover) && (_fadeOpacity != 1))
                {
                    _currentFadeOpacity = 1;
                    Fade();
                }
            }
            else
            {
                if (_fullOpacityOnHover)
                {
                    _currentFadeOpacity = FadeOpacity;
                    Fade();
                }
            }

        }
        #endregion Fader
    }
}