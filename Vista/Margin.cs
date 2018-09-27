using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Globalization;

namespace Signature.Vista
{
    /// <summary>
    /// Représente les marges du formulaire pour afficher les effets Aero
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    //[TypeConverter(typeof(MarginConverter))]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [ComVisible(true)]
    public struct Margin
    {
        /// <summary>
        /// Marge gauche
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public int Left;
        /// <summary>
        /// Marge droite
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public int Right;
        /// <summary>
        /// Marge du haut
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public int Top;
        /// <summary>
        /// Marge du bas
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public int Bottom;

        public static readonly Margin None = new Margin(-1);

        public Margin(int left, int right, int top, int bottom) {
            this.Left = left;
            this.Right = right;
            this.Top = top;
            this.Bottom = bottom;
        }

        public Margin(int all) : this(all, all, all, all) { }

        static Margin() { 
            
        }

        public override string ToString()
        {
            return string.Format("{0}; {1}; {2}; {3}",
                    this.Left.ToString(CultureInfo.CurrentCulture),
                    this.Right.ToString(CultureInfo.CurrentCulture),
                    this.Top.ToString(CultureInfo.CurrentCulture),
                    this.Bottom.ToString(CultureInfo.CurrentCulture)
                );
            //return string.Format("Left={0}, Right={1}, Top={2}, Bottom={3}",
            //        this.Left.ToString(CultureInfo.CurrentCulture),
            //        this.Right.ToString(CultureInfo.CurrentCulture),
            //        this.Top.ToString(CultureInfo.CurrentCulture),
            //        this.Bottom.ToString(CultureInfo.CurrentCulture)
            //    );
        }
    }
}
