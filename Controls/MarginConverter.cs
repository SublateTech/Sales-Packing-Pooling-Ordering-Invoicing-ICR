using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

using Maf.Windows.Forms.DWM;

namespace Maf.ComponentModel
{
    public class MarginConverter : ExpandableObjectConverter
    {
        public MarginConverter() { }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            //MessageBox.Show("CanConvertFrom\t" + sourceType.Name);
            if (sourceType == typeof(string)) {
                return true;
            }

            //if (sourceType == typeof(InstanceDescriptor)) {
            //    return true;
            //}

            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            //MessageBox.Show("CanConvertTo+\t" + destinationType.Name);
            if (destinationType == typeof(InstanceDescriptor)) {
                return true;
            }

            //if (destinationType == typeof(string)) {
            //    return true;
            //}
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            //MessageBox.Show("ConvertFrom\t" + (string)value);
            string text = value as string;
            if (text != null) {
                text = text.Trim();

                if (text.Length != 0)
                {
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }

                    char separator = culture.TextInfo.ListSeparator[0];
                    //MessageBox.Show(separator.ToString());
                    string[] textArray = text.Split(separator);
                    int[] numArray = new int[textArray.Length];

                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));
                    for (int i = 0; i < text.Length; i++)
                    {
                        numArray[i] = (int)intConverter.ConvertFromString(context, culture, textArray[i]);
                    }

                    if (numArray.Length != 4)
                    {
                        throw new ArgumentException("Format de chaine incorrect");
                    }

                    return new Margin(numArray[0], numArray[1], numArray[2], numArray[3]);
                }
                return null;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null) {
                throw new ArgumentNullException("destinationType");
            }

            if (value is Margin) {
                if (destinationType == typeof(string)) {
                    Margin margin = (Margin)value;
                    if (culture == null) {
                        culture = CultureInfo.CurrentCulture;
                    }

                    string separator = culture.TextInfo.ListSeparator + "";
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
                    string[] textArray = new string[4];
                    int i = 0;
                    textArray[i++] = converter.ConvertToString(context, culture, margin.Left);
                    textArray[i++] = converter.ConvertToString(context, culture, margin.Right);
                    textArray[i++] = converter.ConvertToString(context, culture, margin.Top);
                    textArray[i++] = converter.ConvertToString(context, culture, margin.Bottom);

                    return string.Join(separator, textArray);
                }

                if (destinationType == typeof(InstanceDescriptor)) {
                    Margin margin = (Margin)value;
                    ConstructorInfo constructorInfo = typeof(Margin).GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) });
                    if (constructorInfo != null) {
                        return new InstanceDescriptor(constructorInfo, new object[] { margin.Left, margin.Right, margin.Top, margin.Bottom });
                    }
                }
            }


            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            object[] obj = new object[4];
            obj[0] = propertyValues["Left"];
            obj[1] = propertyValues["Right"];
            obj[2] = propertyValues["Top"];
            obj[3] = propertyValues["Bottom"];

            for (int i = 0; i < 4; i++)
            {
                if (obj[i] == null || !(obj[i] is int))
                {
                    throw new ArgumentException("Valeur de propriété non valide.");
                }
            }

            return new Margin((int)obj[0], (int)obj[1], (int)obj[2], (int)obj[3]);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(Margin), attributes).Sort(new string[] { "Left", "Right", "Top", "Bottom" });
            //return TypeDescriptor.GetProperties(typeof(Margin));
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
